using MarketEase.Domain.Entities;
using MarketEase.Domain.ValueObjects;

namespace MarketEase.Domain.UnitTests.Entities;

public class SuperMarketTests
{
    [Fact]
    public void Constructor_ReceivesValidInput_ReturnsValidSuperMarket()
    {
        const string NAME = "Abe Supermarket";
        var ADDRESS = new Address("Brazil", "São Paulo", "13505720", "Rua Macedônia", "1324");
        var CNPJ = new CNPJ("05570714000159");

        var superMarket = new SuperMarket(NAME, ADDRESS, CNPJ);

        Assert.True(superMarket.IsValid);
    }

    [Fact]
    public void Constructor_ReceivesInvalidInput_ReturnsInvalidSuperMarket()
    {
        const string InvalidName = "";
        var ADDRESS = new Address("Brazil", "São Paulo", "13505720", "Rua Macedônia", "1324");
        var CNPJ = new CNPJ("05570714000159");
        
        var superMarket = new SuperMarket(InvalidName, ADDRESS, CNPJ);

        Assert.False(superMarket.IsValid);
    }
}