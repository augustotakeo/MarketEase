using MarketEase.Domain.ValueObjects;

namespace MarketEase.Domain.UnitTests.ValueObjects;

public class CNPJTests
{
    [Fact]
    public void Constructor_ReceivesValidInput_ReturnsValidCNPJ()
    {
        var cnpj = new CNPJ("47960950000121");
        Assert.True(cnpj.IsValid);
    }

    [Theory]
    [InlineData("47.960.950/0001-21")]
    [InlineData("479609500001211")]
    [InlineData("479609500001")]
    [InlineData("12345678901234")]
    public void Constructor_ReceivesInvalidInput_ReturnsInvalidCNPJ(string number)
    {
        var cnpj = new CNPJ(number);
        Assert.False(cnpj.IsValid);
    }
}
