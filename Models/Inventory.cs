using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Inventory
    {
        [Key]
        public int itemID { get; set; }

        public string name { get; set; }

        public string description { get; set; }
        
        public string condition { get; set; }

        public string aisle { get; set; }

        public int quantity { get; set; }

        public int price { get; set; }

        // Foreign Key
        public Purchased purchased { get; set; }

        /*
        // Default Constructor
        Inventory() { }

        // Parameterized Constructor
        Inventory(string name, string description, string condition, string aisle,
            int quantity, int price) {
            this.name = name;
            this.description = description;
            this.condition = condition;
            this.aisle = aisle;
            this.quantity = quantity;
            this.price = price;
        }
        */
    }
}
