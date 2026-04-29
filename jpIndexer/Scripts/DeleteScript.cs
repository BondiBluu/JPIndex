using Microsoft.Data.Sqlite;

public static class DeleteScript
{
    public static void Delete(string connectionString)
    {
        ViewScript.GetRecords(connectionString);
        string whatToDeleteBy;

        Console.WriteLine("Choose word to delete. Choose by \n\nKanji\n\nHiragana(hira) or Katakana(kana)\n\nRomaji\n\nEnglish\n\nPress 0 to exit\n\n");
        string option = Console.ReadLine();

        if(option == "0")
        {
            MainPageScript.MainMenu(connectionString);
        }
        else if (!Enum.IsDefined(typeof(SearchOptions), option.ToUpper()))
        {
            Console.WriteLine("Invalid command.\n");
            Delete(connectionString);
        }
        else
        {
            whatToDeleteBy = FindWordOption.SearchForWord(option);

            Console.Write("\nType in word to delete: ");
            string wordToSearch = Console.ReadLine();

            SQLDelete(connectionString, whatToDeleteBy, wordToSearch);
        }
    }

    public static void SQLDelete(string connectionString, string whatToDeleteBy, string wordToDelete)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand tableCmd = connection.CreateCommand();

            tableCmd.CommandText = $"DELETE FROM japanese_index WHERE {whatToDeleteBy} = '{wordToDelete}'";

            int rowCount = tableCmd.ExecuteNonQuery();

            if(rowCount == 0)
            {
                Console.WriteLine($"\n\nWord {wordToDelete} doesn't exist.\n\n");
                Delete(connectionString);
            }

            connection.Close();
        }
    }
}