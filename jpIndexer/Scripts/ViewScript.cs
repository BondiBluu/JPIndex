using Microsoft.VisualBasic;
using Microsoft.Data.Sqlite;

public static class ViewScript
{
    public static void GetRecords(string connectionString)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand tableCmd = connection.CreateCommand();

            tableCmd.CommandText = 
                $"SELECT * FROM japanese_index";

            List<JPIndex> tableData = new List<JPIndex>();

            SqliteDataReader reader = tableCmd.ExecuteReader();
        }
    }

    public class JPIndex
    {
        public int Id { get; set; }
        public string Kanji { get; set; }
        public string Hiragana { get; set; }
        public string Romaji { get; set; }
        public string English { get; set; }
    }
}