using Npgsql;

namespace TestProject6;

public class DatabaseFixture
{
    public DatabaseFixture()
    {
        ConnectionString = "Host=localhost;port=54323;Username=mep;Password=Metropolitan2019";

        using var dbConnection = new NpgsqlConnection(ConnectionString);
        dbConnection.Open();
        using var cmd = dbConnection.CreateCommand();
        cmd.CommandText = "DROP SCHEMA IF EXISTS test CASCADE; CREATE SCHEMA test;";
        cmd.ExecuteNonQuery();
    }

    public string ConnectionString { get; }
}