using Microsoft.VisualBasic;
using Microsoft.Data.Sqlite;

public static class ViewScript
{
    public static void GetRecords(string connectionString)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand tableCmd = connection.CreateCommand();

            tableCmd.CommandText = 
                $"SELECT * FROM japanese_index";

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

    public class JPIndex
    {
        public int Id { get; set; }
        public string Kanji { get; set; }
        public string Hiragana { get; set; }
        public string Romaji { get; set; }
        public string English { get; set; }
    }
}