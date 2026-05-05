using Microsoft.Data.Sqlite;

public static class UpdateScript
{
    public static void Update(string connectionString)
    {
        Console.Clear();
        ViewScript.GetRecords(connectionString);

        string wordToSearch = InsertScript.GetStringInput("\n\nType the English word or phrase of the row you'd like to update. Type 0 to return to the Main Menu.\n\n");

        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand checkCmd = connection.CreateCommand();

            checkCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM japanese_index WHERE English = {wordToSearch})";
        }
    }
}