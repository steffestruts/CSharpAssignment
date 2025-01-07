using Business.Services;
using Business.Interfaces;
using PresentationConsole.Dialogs;
using Microsoft.Extensions.DependencyInjection;

// Skapar en ServiceCollection
var serviceCollection = new ServiceCollection();
// Registrerar tjänster
serviceCollection.AddSingleton<IFileService>(new FileService("contacts.json"));
serviceCollection.AddSingleton<IContactService, ContactService>();
serviceCollection.AddSingleton<MenuDialogs>();

// Bygger ServiceProvider
var serviceProvider = serviceCollection.BuildServiceProvider();
// Hämtar en instans av MenuDialogs
var menuDialogs = serviceProvider.GetRequiredService<MenuDialogs>();
// Kör huvudmenyn
menuDialogs.MainMenu();