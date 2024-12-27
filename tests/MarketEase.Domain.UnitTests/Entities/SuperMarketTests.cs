using MarketEase.Domain.Entities;

namespace MarketEase.Domain.UnitTests.Entities;

public class SuperMarketTests
{
    [Fact]
    public void Constructor_ReceivesValidInput_ReturnsValidSuperMarket()
    {
        const string NAME = "Abe Supermarket";
        const string ADDRESS = "Rua dos anjos, 3400";
        const string CNPJ = "05570714000159";

        var superMarket = new SuperMarket(NAME, ADDRESS, CNPJ);

        Assert.True(superMarket.IsValid);
    }
}