namespace Business.Interfaces;

// IFileService används för att skapa ett kontrakt för att skapa en service som hanterar filer.
public interface IFileService
{
    bool SaveToFile(string content);
    string ReadFromFile();
}
