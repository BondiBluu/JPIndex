using Microsoft.Data.Sqlite;

public static class InsertScript
{
    public static void Insert(string connectionString)
    {

        string kanji = GetStringInput.GetInput("Input Kanji, if any: ");

        string hiraKana = GetStringInput.GetInput("Input Hiragana or Katakana: ");

        string romaji = GetStringInput.GetInput("Input Romaji:");

        string english = GetStringInput.GetInput("Input English translation: ");

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


}