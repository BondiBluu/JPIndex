public static class SearchScript
{
    public static void Search(string connectionString)
    {
        Console.Write("What would you like to search by?\n\nKanji\nHiragana(hira) or Katakana(kana)\nRomaji\nEnglish\nPress 0 to exit\n");
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
            SearchForWord(option);
        }

    }

    public static void SearchForWord(string searchCategory)
    {
        Console.WriteLine("Searching.");
    }
}