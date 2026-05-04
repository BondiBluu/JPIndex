using Microsoft.Data.Sqlite;

public static class InsertScript
{
    public static void Insert(string connectionString)
    {

        string kanji = GetStringInput("Input Kanji, if any: ");

        string hiraKana = GetStringInput("Input Hiragana or Katakana: ");

        string romaji = GetStringInput("Input Romaji:");

        string english = GetStringInput("Input English translation: ");

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand tableCmd = connection.CreateCommand();

            tableCmd.CommandText = 
                $"INSERT INTO japanese_index(Kanji, Hiragana, Romaji, English) VALUES('{kanji}','{hiraKana}','{romaji}','{english}')";

                tableCmd.ExecuteNonQuery();

                connection.Close();
        }
        
        Insert(connectionString);
    }

    public static string GetStringInput(string message)
    {
        Console.WriteLine(message);

        string? input = Console.ReadLine();

        return input ?? string.Empty;
    }
}