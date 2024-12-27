using Flunt.Notifications;
using Flunt.Validations;
using MarketEase.Domain.ValueObjects;

namespace MarketEase.Domain.Entities;

public class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public CPF CPF { get; private set; }
    public bool IsAdmin { get; private set; }
    public User(string name, string email, string password, CPF cpf, bool isAdmin)
    {
        Name = name;
        Email = email;
        Password = password;
        CPF = cpf;
        IsAdmin = isAdmin;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsBetween(name.Length, 3, 60, "User.Name", "Name lenght must be greater than 3")
            .IsEmail(email, "User.Email", "Email should be valid")
            .IsGreaterOrEqualsThan(password.Length, 8, "User.Password", "Password length should be greater than 3"));
 
        AddNotifications(cpf);
    }
}