﻿using Business.Interfaces;

namespace Business.Services;

// FileService används för att hantera filer.
public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    // Konstruktor
    public FileService(string fileName)
    {
        _directoryPath = "Data";
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    // Läser innehåll från fil
    public string ReadFromFile()
    {
        if (File.Exists(_filePath))
        {
            return File.ReadAllText(_filePath);
        }
        return null!;
    }

    // Sparar innehåll till fil med try-catch
    public bool SaveToFile(string content)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            File.WriteAllText(_filePath, content);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
