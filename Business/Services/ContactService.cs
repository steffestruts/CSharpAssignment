using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using System.Text.Json;

namespace Business.Services;

// ContactService används för att hantera kontakter.
public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;
    private List<Contact> _contacts = [];

    // Läser in kontakter från filen
    public IEnumerable<Contact> ReadFromFile()
    {
        var content = _fileService.ReadFromFile();

        try
        {
            // Deserialisera JSON till en lista med kontakter
            _contacts = JsonSerializer.Deserialize<List<Contact>>(content)!;
        }
        catch
        {
            // Om det inte finns några kontakter att läsa från filen så skapas en tom lista
            _contacts = [];
        }

        return _contacts;
    }

    // Sparar en kontakt till filen
    public bool Save(ContactRegistrationForm form)
    {
        try
        {
            // Skapa en ny kontakt
            var contact = ContactFactory.Create(form);
            _contacts.Add(contact);

            // Serialisera listan med kontakter till JSON
            var json = JsonSerializer.Serialize(_contacts);
            var result = _fileService.SaveToFile(json);
            return result;
        }
        catch (Exception ex)
        {
            // Något fel inträffade med att spara kontakten
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
