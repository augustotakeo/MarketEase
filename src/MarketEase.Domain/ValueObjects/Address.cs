using Flunt.Notifications;
using Flunt.Validations;

namespace MarketEase.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Country { get; private set; } 
    public string City { get; private set; }
    public string State { get; private set; }
    public string Neighborhood { get; private set; }
    public string PostalCode { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }

    public Address(string country, string state, string city, string neighborhood, string postalCode, string street, string number)
    {
        Country = country;
        City = city;
        State = state;
        Neighborhood = neighborhood;
        PostalCode = postalCode;
        Street = street;
        Number = number;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterOrEqualsThan(Country, 3, "Address.Country", "Country length should be greater than 2")
            .IsGreaterOrEqualsThan(City, 3, "Address.City", "City length should be greater than 2")
            .IsGreaterOrEqualsThan(State, 3, "Address.State", "State length should be greater than 2")
            .IsGreaterOrEqualsThan(Neighborhood, 3, "Address.Neighborhood", "Neighborhood length should be greater than 2")
            .AreEquals(PostalCode, 8, "Address.PostalCode", "PostalCode length should be equals to 8")
            .Matches(PostalCode, "^[0-9]+$", "Address.PostalCode", "PostalCode should have only digits")
            .IsGreaterOrEqualsThan(Street, 3, "Address.Street", "Street length should be greater than 2")
            .Matches(Number, "^[0-9]+$|s[/]n", "Address.Number", "Number should have only digits or be equals to s/n"));
    }
}
