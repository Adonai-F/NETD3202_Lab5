using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public class Purchased
    {
        public int purchasedId { get; set; }

        public string itemPurchased { get; set; }

        public string customerName { get; set; }

        public int phoneNumber { get; set; }

        public string address { get; set; }

        // Foreign Key
        public ICollection<Inventory> Inventories { get; set; }

        // Default Constructor
        //Purchased() { }

        // Parameterized Constructor
        /*
        Purchased(string customerName, int number, string address, string item)
        {
            this.customerName = customerName;
            this.phoneNumber = number;
            this.address = address;
            this.itemPurchased = item;
        }

        // Order Details Method
        public override string ToString()
        {
            return "Customer Name: " + this.customerName +
                "\nCustomer Phone Number: " + this.phoneNumber
                + "\nCustomer Address: " + this.address
                + "\nItem Purchased: " + this.itemPurchased;
        }
        */
    }
}
