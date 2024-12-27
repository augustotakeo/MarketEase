using MarketEase.Domain.Entities;
using MarketEase.Domain.ValueObjects;

namespace MarketEase.Domain.UnitTests.Entities;

public class UserTests
{
    [Fact]
    public void Constructor_ReceivesValidInput_ReturnsValidUser()
    {
        const string NAME = "Abilio Diniz";
        const string EMAIL = "abilio.diniz@gmail.com";
        const string PASSWORD = "minhasenhasupersecreta";
        var CPF = new CPF("96862768077");
        
        var user = new User(NAME, EMAIL, PASSWORD, CPF);

        Assert.True(user.IsValid);
    }

    [Theory]
    [InlineData("", "abilio.diniz@gmail.com", "minhasenhasupersecreta", "96862768077")]
    [InlineData("Abilio Diniz", "invalid email", "minhasenhasupersecreta", "96862768077")]
    [InlineData("Abilio Diniz", "abilio.diniz@gmail.com", "invalid", "96862768077")]
    [InlineData("Abilio Diniz", "abilio.diniz@gmail.com", "invalid", "96862768077dd")]
    public void Constructor_ReceivesInvalidInput_ReturnsInvalidUser(string name, string email, string password, string cpf)
    {
        var user = new User(name, email, password, new CPF(cpf));

        Assert.False(user.IsValid);
    }
}