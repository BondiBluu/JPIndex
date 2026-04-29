public static class FindWordOption
{
        public static string SearchForWord(string searchCategory)
    {
        switch (searchCategory.ToUpper())
        {
            case "KANJI":
                return "Kanji";
            case "HIRAGANA":
            case "HIRA":
            case "KATAKANA":
            case "KANA":
                return "Hiragana";
            case "ROMAJI":
                return "Romaji";
            case "ENGLISH":
                return "English";
            default:
                return "Invalid";
        }
    }
}