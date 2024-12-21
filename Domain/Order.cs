using Vogen;

namespace Domain;

[ValueObject<int>]
public partial struct OrderId;

public class Order
{
    public OrderId? Id { get; set; }
    public string Name { get; set; }
}