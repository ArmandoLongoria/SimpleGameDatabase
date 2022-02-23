using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Database
{
    class Game
    {
        private string title;
        private string genre;
        private double price;
        private int quantity;

        public string myTitle { get; set; }
        public int myQuantity { get; set; }

        public  Game(string title, string genre, double price, int quantity)
        {
            this.title = title;
            this.genre = genre;
            this.price = price;
            this.quantity = quantity;
            myTitle = title;
            myQuantity = quantity;
        }

        public string toString()
        {
            return "Title: " + title + "\nGenre: " + genre + " \nPrice: " + price + " \nQuantity: "+ quantity +"\n";
        }

        public  void UpdateInfo()
        {
            quantity = myQuantity;
        }
        

    }
}
