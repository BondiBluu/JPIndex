using Microsoft.Data.Sqlite;

public static class UpdateScript
{
    public static void Update(string connectionString)
    {
        Console.Clear();
        ViewScript.GetRecords(connectionString);

        string wordToSearch = GetStringInput.GetInput("\n\nType the English word or phrase of the row you'd like to update. Type 0 to return to the Main Menu.\n\n");

        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand checkCmd = connection.CreateCommand();

            checkCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM japanese_index WHERE English = @word)";
            checkCmd.Parameters.AddWithValue("@word", wordToSearch);
            int checkQuery = Convert.ToInt32(checkCmd.ExecuteScalar());

            if(checkQuery == 0)
            {
                Console.WriteLine("This row doesn't exist.");
                connection.Close();
                Update(connectionString);
                return;
            }


        }
    }
}