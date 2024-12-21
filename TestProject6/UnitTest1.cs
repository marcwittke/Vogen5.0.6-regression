using System.Collections.Specialized;
using System.Reflection;
using Domain;
using Marten;

namespace TestProject6;

public class UnitTest1 : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public UnitTest1(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void CanUseVogen()
    {
        var id = OrderId.From(1234);
        var order = new Order { Id = id, Name = "Hello" };

    }
    
    [Fact]
    public async Task Test1()
    {
        var theStore = DocumentStore.For(opts =>
        {
            opts.Connection(_fixture.ConnectionString);
            opts.DatabaseSchemaName = "test";
        });

        var theSession = theStore.LightweightSession();
        
        var id = OrderId.From(1234);
        var order = new Order { Id = id, Name = "Hello" };
        
        theSession.Store(order);
        
        await theSession.SaveChangesAsync();
    }
}