using MarketEase.Domain.ValueObjects;

namespace MarketEase.Domain.UnitTests.Entities;

public class AddressTests
{

    
    [Theory]
    [InlineData("Brasil", "Guarulhos", "São Paulo", "Vila Itapegica", "07034911", "Rod. Pres. Dutra", "225")]
    [InlineData("Brasil", "Guarulhos", "São Paulo", "Vila Itapegica", "07034911", "Rod. Pres. Dutra", "s/n")]
    public void Constructor_ReceivesValidInput_ReturnsValidAddress(string COUNTRY, string CITY, string STATE, string BAIRRO, string POSTALCODE, string STREET, string NUMBER)
    {
        var address = new Address(COUNTRY, CITY, STATE, BAIRRO, POSTALCODE, STREET, NUMBER);
        Assert.True(address.IsValid);
    }

    [Theory]
    [InlineData("", "Guarulhos", "São Paulo", "Vila Itapegica", "07034911", "Rod. Pres. Dutra", "225")]
    [InlineData("Brazil", "", "São Paulo", "Vila Itapegica", "07034911", "Rod. Pres. Dutra", "225")]
    [InlineData("Brazil", "Guarulhos", "", "Vila Itapegica", "07034911", "Rod. Pres. Dutra", "225")]
    [InlineData("Brazil", "Guarulhos", "São Paulo", "", "07034911", "Rod. Pres. Dutra", "225")]
    [InlineData("Brazil", "Guarulhos", "São Paulo", "Vila Itapegica", "", "Rod. Pres. Dutra", "225")]
    [InlineData("Brazil", "Guarulhos", "São Paulo", "Vila Itapegica", "07034911", "", "225")]
    [InlineData("Brazil", "Guarulhos", "São Paulo", "Vila Itapegica", "07034911", "Rod. Pres. Dutra", "")]
    public void Constructor_ReceivesInvalidInput_ReturnsInvalidAddress(string COUNTRY, string CITY, string STATE, string BAIRRO, string POSTALCODE, string STREET, string NUMBER)
    {
        var address = new Address(COUNTRY, CITY, STATE, BAIRRO, POSTALCODE, STREET, NUMBER);
        Assert.False(address.IsValid);
    }

}
