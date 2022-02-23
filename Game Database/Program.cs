using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Database
{
    class Program
    {
        static int inventorySize = 0;
        static int purchaseQuantity;
        static string purchaseQuantityString;
        static string command;
        static string gameSelection;
        static string gameToBuy;
        static bool acceptableInput;
        static Game[] games = new Game[5];


        public static void Main(string[] args)
        {
            Game rayman = new Game("Rayman", "Fantasy", 15, 1);
            Game tekken = new Game("Tekken", "Fighting", 45, 2);
            Game princeOfPersia = new Game("Prince of Persia", "Adventure", 60, 5);
            Game witcher = new Game("Witcher", "Fantasy", 50, 1);
            Game deathStranding = new Game("Death Stranding", "Sci-Fi", 30, 1);
            Game noMansSky = new Game("No Man's Sky", "Sci-Fi", 30, 6);

            Console.WriteLine("=============================================== GAME STORE INVENTORY PROGRAM ===========================================");
            Console.WriteLine("============================================== Copyright ARMANDO LONGORIA 2022 =========================================\n");
            AddToInventory(rayman);
            AddToInventory(tekken);
            AddToInventory(princeOfPersia);
            AddToInventory(witcher);
            AddToInventory(deathStranding);
            AddToInventory(noMansSky);
            
            MainMenu();



            Console.Read();
        }

        public static void MainMenu()
        {
            Console.WriteLine("===================================================== MAIN MENU ========================================================");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("CHECK = Display Inventory\nSEARCH = Search Inventory\nBUY = Purchase game\nEXIT = Close Program\n");
            command = Console.ReadLine();
            CheckInput();
        }

        public static void CheckInput()
        {
            command = command.ToUpper();
            if (command == "CHECK" || command == "SEARCH" || command == "BUY" || command == "EXIT")
            {
                acceptableInput = true;
                Console.WriteLine("\nWorking...\n");
                CheckCommand();
            }
            else
            {
                acceptableInput = false;
                Console.WriteLine("\nINVALID INPUT");
                MainMenu();
            }
        }

        public static void CheckCommand()
        {
            if (command == "BUY")
            {
                Buy();
            }
            else if (command == "EXIT")
            {
                Exit();
            }
            else if(command == "CHECK")
            {
                DisplayInventory();
            }
            else if (command == "SEARCH")
            {
                SearchInventory();
            }
        }

        public static void Buy()
        {
            Console.WriteLine("Which game would you like to buy?");
            gameToBuy = Console.ReadLine();
            foreach(Game g in games)
            {
                if(g.myTitle.Equals(gameToBuy, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Game found.\n");
                    Console.WriteLine("How many copies would you like to purchase?");
                    purchaseQuantityString = Console.ReadLine();
                    if(int.TryParse(purchaseQuantityString, out purchaseQuantity))
                    {
                        if(g.myQuantity >= purchaseQuantity)
                        {
                            g.myQuantity = g.myQuantity - purchaseQuantity;
                            g.UpdateInfo();
                            if(g.myQuantity == 0)
                            {
                                RemoveFromInventory(g.myTitle);
                            }
                            Console.WriteLine("Thank you for your purchase(s)!");
                            MainMenu();
                            return;
                        }
                        Console.WriteLine("Not enough copies in stock!\n");
                        MainMenu();
                        return;
                    }
                }             
            }
            Console.WriteLine("No match found for: " + gameToBuy);
            MainMenu();
            return;

        }

        public static void Exit()
        {
            Console.WriteLine("Press Enter twice to Exit Program");
            Console.ReadKey();
        }

        public static void DisplayInventory()
        {
            Console.WriteLine("==================================================== INVEMTORY =========================================================");
            foreach (Game g in games)
            {
                Console.WriteLine(g.toString());
            }
            MainMenu();
        }

        public static void AddToInventory(Game newGame)
        {
            if(inventorySize == games.Length)
            {
                Console.WriteLine("Inventory full\n");
                return;
            }

            games[inventorySize++] = newGame;
            newGame.UpdateInfo();
            Console.WriteLine("{0} added to inventory\n", newGame.myTitle);
        }

        public static void SearchInventory()
        {
            Console.WriteLine("Which game would you like to search?");
            gameSelection = Console.ReadLine();
            foreach(Game g in games)
            {
                if (g.myTitle.Equals(gameSelection, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("========================================================================================================================");
                    Console.WriteLine("RESULTS");
                    Console.WriteLine("========================================================================================================================");
                    Console.WriteLine(g.toString()); 
                    MainMenu();
                    return;
                }
            }
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("No matches found for: " + gameSelection);
            MainMenu();
        }

        public static void RemoveFromInventory(string deleteTitle)
        {
            int j = 0;
            Game[] tempGames = new Game[--inventorySize];
            for(int i = 0; i < games.Length; i++)
            {
                if(deleteTitle == games[i].myTitle)
                {
                    continue;
                }
                tempGames[j++] = games[i];
            }
            games = tempGames;
        }

    }
}
