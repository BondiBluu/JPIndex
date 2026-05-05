   public class GetStringInput
{
     public static string GetInput(string message)
    {
        Console.WriteLine(message);

        string? input = Console.ReadLine();

        return input ?? string.Empty;
    }
}
   
   