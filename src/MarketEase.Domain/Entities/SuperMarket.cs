using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using MarketEase.Domain.ValueObjects;

namespace MarketEase.Domain.Entities;

public class SuperMarket : Entity
{
    public string Name { get; private set; }
    public Address Address { get; private set; }
    public CNPJ CNPJ { get; private set; }
    
    public SuperMarket(string name, Address address, CNPJ cnpj)
    {
        Name = name;
        Address = address;
        CNPJ = cnpj;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(Name, 3, "SuperMarket.Name", "Name length should be greater than 3"));

        AddNotifications(CNPJ, Address);
    }
}