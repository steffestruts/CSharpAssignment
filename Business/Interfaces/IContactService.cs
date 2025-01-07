using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

// Denna interface används för att skapa ett kontrakt för att skapa en service som hanterar kontakter.
public interface IContactService
{
    bool Save(ContactRegistrationForm form);
    IEnumerable<Contact> ReadFromFile();
}
