using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace MarketEase.Domain.Entities;

public class SuperMarket : Entity
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string CNPJ { get; private set; }
    
    public SuperMarket(string name, string address, string cnpj)
    {
        Name = name;
        Address = address;
        CNPJ = cnpj;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(Name, 3, "SuperMarket.Name", "Name length should be greater than 3"));
    }
}