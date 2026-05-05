public static class UpdateScript
{
    public static void Update(string connectionString)
    {
        Console.Clear();
        ViewScript.GetRecords(connectionString);
    }
}