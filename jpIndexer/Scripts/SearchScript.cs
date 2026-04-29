using Microsoft.Data.Sqlite;

public static class SearchScript
{
    public static void Search(string connectionString)
    {
        string whatToSearchBy;
        Console.Write("\nWhat would you like to search by?\n\nKanji\n\nHiragana(hira) or Katakana(kana)\n\nRomaji\n\nEnglish\n\nPress 0 to exit\n\n");
        string option = Console.ReadLine();

        if(option == "0")
        {
            MainPageScript.MainMenu(connectionString);
        }
        else if (!Enum.IsDefined(typeof(SearchOptions), option.ToUpper()))
        {
            Console.WriteLine("Invalid command.\n");
            Search(connectionString);
        }
        else
        {
            whatToSearchBy = FindWordOption.SearchForWord(option);

            Console.Write("\nType in word to search: ");
            string wordToSearch = Console.ReadLine();

            SQLSearch(connectionString, whatToSearchBy, wordToSearch);
        }

    }

    public static void SQLSearch(string connectionString, string searchCategory, string wordToSearch)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand tableCmd = connection.CreateCommand();

            tableCmd.CommandText = 
                $"SELECT * FROM japanese_index WHERE {searchCategory} LIKE '%{wordToSearch}%'";

            List<JPIndex> tableData = new List<JPIndex>();

            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tableData.Add(
                        new JPIndex
                        {
                            Id = reader.GetInt32(0),
                            Kanji = reader.GetString(1),
                            Hiragana = reader.GetString(2),
                            Romaji = reader.GetString(3),
                            English = reader.GetString(4)
                        }
                    );
                }
            }
            else
            {
                Console.WriteLine("No rows found");
            }

            connection.Close();

            foreach (JPIndex index in tableData)
            {
                Console.WriteLine($"Kanji: {index.Kanji}\tHira/Kata: {index.Hiragana}\tRomaji: {index.Romaji}\tEnglish: {index.English}");
            }
        }
    }
}