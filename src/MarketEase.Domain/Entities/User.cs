using Flunt.Notifications;
using Flunt.Validations;
using MarketEase.Domain.ValueObjects;

namespace MarketEase.Domain.Entities;

public class User : Notifiable<Notification>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public CPF CPF { get; set; }
    public User(string name, string email, string password, CPF cpf)
    {
        Name = name;
        Email = email;
        Password = password;
        CPF = cpf;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsBetween(name.Length, 3, 60, "User.Name", "Name lenght must be greater than 3")
            .IsEmail(email, "User.Email", "Email should be valid")
            .IsGreaterOrEqualsThan(password.Length, 8, "User.Password", "Password length should be greater than 3"));
 
        AddNotifications(cpf);
    }
}