public static class MainPageScript
{
    public static void MainMenu(string connectionString)
    {
        bool closeApp = false;

        while (!closeApp)
        {
            Console.WriteLine("\n\nMain Menu");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("\nType 0 to Close Application");
            Console.WriteLine("\nType 1 to View All");
            Console.WriteLine("\nType 2 to Insert Record");
            Console.WriteLine("\nType 3 to Delete Record");
            Console.WriteLine("\nType 4 to Update Record\n");
            Console.WriteLine("\nType 5 to Search All");
            

            string commandInput = Console.ReadLine();

            switch (commandInput)
            {
                case "0":
                    closeApp = true;
                    Environment.Exit(0);
                break;
                case "1":
                    ViewScript.GetRecords(connectionString);
                break;
                case "2":
                    InsertScript.Insert();
                break;
                case "3":
                    DeleteScript.Delete();
                break;
                case "4":
                    UpdateScript.Update();
                break;
                case "5":
                    SearchScript.Search();
                break;
                default:
                Console.WriteLine("\nInvalid Command. Please type a number from 0 to 5.\n");
                break;
            }
        }
    }
}