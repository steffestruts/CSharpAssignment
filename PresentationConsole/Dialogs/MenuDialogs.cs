using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace PresentationConsole.Dialogs;

public class MenuDialogs(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void MainMenu() 
    {
        while (true) 
        {
            Console.Clear();
            Console.WriteLine("1. Visa kontakter.");
            Console.WriteLine("2. Skapa en ny kontakt.");
            Console.WriteLine("3. För att avsluta applikationen.");
            Console.WriteLine();
            Console.Write("\nVar vänlig och välj ett alternativ: ");
            var choice = Console.ReadLine()!;
            switch (choice)
            {
                // Visar alla kontakter
                case "1":
                    ViewAllContacts();
                    break;
                // Skapa en ny kontakt
                case "2":
                    CreateContact();
                    break;
                // Avsluta applikationen
                case "3":
                    Console.WriteLine("\nHej då!");
                    Environment.Exit(-1);
                    return;
                // Ogiltig inmatning - Försök igen
                default:
                    Console.Clear();
                    Console.WriteLine("Ogiltig inmatning! Försök igen.\n");
                    break;
            }
        }
    }

    public void ViewAllContacts()
    {
        // Rensar konsolfönstret
        Console.Clear();

        // Visar en rubrik
        Console.WriteLine("---> Visar alla kontakter \n");

        // Hämtar alla kontakter
        var contacts = _contactService.ReadFromFile();

        // Loopa igenom alla kontakter och skriv ut dem, en efter en
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{"Id:",-15}{contact.Id}");
            Console.WriteLine($"{"Namn:",-15}{contact.FirstName} {contact.LastName}"); // Flyttar ihop förnamn och efternamn för göra fullständigt namn
            Console.WriteLine($"{"Adress:",-15}{contact.Address}");
            Console.WriteLine($"{"Postnummer:",-15}{contact.PostalCode}");
            Console.WriteLine($"{"Ort/stad:",-15}{contact.City}");
            Console.WriteLine($"{"E-postadress:",-15}{contact.Email}");
            Console.WriteLine($"{"Telefon:",-15}{contact.PhoneNumber}\n");
        }

        Console.WriteLine("Tryck valfri tangent för att gå ut ur visar alla kontakter!");
        Console.ReadKey();
    }

    public void CreateContact()
    {
        // Inmatningen för skapa en ny kontakt, först rensar vi konsolfönstret sen visar vi en rubrik
        Console.Clear();

        // Visar en rubrik
        Console.WriteLine("---> Skapa en ny kontakt \n");

        // Skapar en ny kontakt
        var contact = ContactFactory.Create();

        // Inmatning: Förnamn
        Console.Write("Skriv in förnamn: ");
        contact.FirstName = Console.ReadLine()!;
        // Inmatning: Efternamn
        Console.Write("Skriv in efternamn: ");
        contact.LastName = Console.ReadLine()!;
        // Inmatning: E-postaddress
        Console.Write("Skriv in e-postaddress: ");
        contact.Email = Console.ReadLine()!;
        // Inmatning: Telefonnummer
        Console.Write("Skriv in telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine()!;
        // Inmatning: Adress
        Console.Write("Skriv in adress: ");
        contact.Address = Console.ReadLine()!;
        // Inmatning: Postnummer
        Console.Write("Skriv in postnummer: ");
        contact.PostalCode = Console.ReadLine()!;
        // Inmatning: Stad/ort
        Console.Write("Skriv in stad/ort: ");
        contact.City = Console.ReadLine()!;
        // Tom rad för bättre läsbarhet
        Console.WriteLine("");

        // Lägger till en ny kontakt med if-else-meddelande om den sparades eller inte. 
        var result = _contactService.Save(contact);
        if (result)
        {
            Console.WriteLine("Kontakten har sparats!");
            Console.WriteLine("Tryck valfri tangent för att gå tillbaka till menyn!");
        }
        else
        {
            Console.WriteLine("Kontakten kunde inte sparas!");
            Console.WriteLine("Tryck valfri tangent för att gå tillbaka till menyn!");
        }
        Console.ReadKey();
    }
}
