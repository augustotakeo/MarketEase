using MarketEase.Domain.ValueObjects;

namespace MarketEase.Domain.UnitTests.ValueObjects;
public class CPFTests
{

    [Fact]
    public void Constructor_ReceivesValidInput_ReturnsValidCPF()
    {
        var number = "78705452015";
        var cpf = new CPF(number);
        Assert.True(cpf.IsValid);
    }

    [Theory]
    [InlineData("12345678901")]
    [InlineData("787.054.520-15")]
    [InlineData("1234567890123")]
    [InlineData("1234567")]
    public void Constructor_ReceivesInvalidInput_ReturnsInvalidCPF(string number)
    {
        var cpf = new CPF(number);
        Assert.False(cpf.IsValid);
    }
}
