namespace Business.Helpers;

// IdGenerator används för att generera ett unikt id.
public class IdGenerator
{
    // Expression method eller förenklad metod av Guid.NewGuid().ToString() precis som videon visade
    public static string Generate() => Guid.NewGuid().ToString();
}
