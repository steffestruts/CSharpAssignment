using Business.Dtos;
using Business.Helpers;
using Business.Models;

namespace Business.Factories;

// ContactFactory används för att skapa en instans av ContactRegistrationForm och Contact.
public static class ContactFactory
{
    public static ContactRegistrationForm Create() => new();

    public static Contact Create(ContactRegistrationForm form) => new()
    {
        Id = IdGenerator.Generate(),
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        PhoneNumber = form.PhoneNumber,
        Address = form.Address,
        PostalCode = form.PostalCode,
        City = form.City
    };
}
