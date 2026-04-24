using Microsoft.Data.Sqlite;

//using connectionString to connect to the DB
string connectionString = @"Data Source=jpIndexer.db";


using(var connection = new SqliteConnection(connectionString))
{
  connection.Open();

  var tableCmd = connection.CreateCommand();

  tableCmd.CommandText = 
  @"CREATE TABLE IF NOT EXISTS japanese_index (
    Id INTEGER PRIMARY KEY AUTOINCREMENT, 
    Kanji TEXT,
    Hiragana TEXT,
    Romaji TEXT,
    English TEXT
  )";

  tableCmd.ExecuteNonQuery();

  connection.Close();
}

MainPageScript.MainMenu();

