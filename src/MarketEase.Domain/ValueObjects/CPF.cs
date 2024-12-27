using System.Diagnostics.CodeAnalysis;
using Flunt.Notifications;
using Flunt.Validations;

namespace MarketEase.Domain.ValueObjects;

public class CPF : Notifiable<Notification>
{
    public string Number { get; init; }

    public CPF(string number)
    {
        Number = number;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .AreEquals(Number.Length, 11, "CPF.Number", "CPF should have 11 characters"));
    }
}