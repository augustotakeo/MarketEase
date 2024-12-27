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
        const bool isAdmin = false;
        
        var user = new User(NAME, EMAIL, PASSWORD, CPF, isAdmin);

        Assert.True(user.IsValid);
    }

    [Theory]
    [InlineData("", "abilio.diniz@gmail.com", "minhasenhasupersecreta", "96862768077", false)]
    [InlineData("Abilio Diniz", "invalid email", "minhasenhasupersecreta", "96862768077", false)]
    [InlineData("Abilio Diniz", "abilio.diniz@gmail.com", "invalid", "96862768077", false)]
    [InlineData("Abilio Diniz", "abilio.diniz@gmail.com", "invalid", "96862768077dd", true)]
    public void Constructor_ReceivesInvalidInput_ReturnsInvalidUser(string name, string email, string password, string cpf, bool isAdmin)
    {
        var user = new User(name, email, password, new CPF(cpf), isAdmin);

        Assert.False(user.IsValid);
    }
}