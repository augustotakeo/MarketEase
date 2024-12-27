using Flunt.Notifications;
using Flunt.Validations;

namespace MarketEase.Domain.ValueObjects;

public class CNPJ : ValueObject
{
    public string Number { get; init; }

    public CNPJ(string number)
    {
        Number = number;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .AreEquals(Number, 14, "CNPJ.Number", "CNPJ should have 14 characters"));
    }
}
