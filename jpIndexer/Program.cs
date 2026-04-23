using Microsoft.Data.Sqlite;

//using connectionString to connect to the DB
string connectionString = @"Data Source=jpIndexer.db";

StartScript.StartingPoint();
InsertScript.Insert();
DeleteScript.Delete();
MainPageScript.CreateMainPage();
SearchScript.Search();
UpdateScript.Update();


using(var connection = new SqliteConnection(connectionString))
{
  
}