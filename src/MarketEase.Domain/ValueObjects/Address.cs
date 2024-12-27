namespace MarketEase.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Country { get; init; } 
    public string City { get; init; }
    public string PostalCode { get; init; }
    public string Street { get; init; }
    public string Number { get; init; }

    public Address(string country, string city, string postalCode, string street, string number)
    {
        Country = country;
        City = city;
        PostalCode = postalCode;
        Street = street;
        Number = number;
    }
}
