using Microsoft.Data.Sqlite;

public static class UpdateScript
{
    public static void Update(string connectionString)
    {
        Console.Clear();
        ViewScript.GetRecords(connectionString);

        string wordToSearch = GetStringInput.GetInput("\n\nType the English word or phrase of the row you'd like to update. Type 0 to return to the Main Menu.\n\n");

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand checkCmd = connection.CreateCommand();

            checkCmd.CommandText = $"SELECT Id FROM japanese_index WHERE English = '{wordToSearch}'";
            int recordId = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (recordId == 0)
            {
                Console.WriteLine("This row doesn't exist.");
                connection.Close();
                Update(connectionString);
                return;
            }

            string kanji = GetStringInput.GetInput("Input Kanji, if any: ");

            string hiraKana = GetStringInput.GetInput("Input Hiragana or Katakana: ");

            string romaji = GetStringInput.GetInput("Input Romaji:");

            string english = GetStringInput.GetInput("Input English translation: ");

            SqliteCommand tableCmd = connection.CreateCommand();
            tableCmd.CommandText = $"UPDATE japanese_index SET Kanji = '{kanji}', Hiragana = '{hiraKana}', Romaji = '{romaji}', English = '{english}' WHERE Id = {recordId}";
            tableCmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}