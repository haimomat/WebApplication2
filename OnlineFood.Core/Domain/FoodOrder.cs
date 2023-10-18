using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFood.Core.Domain
{
    public class FoodOrder
    {
        public int food_id { get; set; }
        public int restaurant_id { get; set; }
        public string food_name { get; set; }
        public string employee_name { get; set; }
        public decimal price { get; set; }
        public string photo { get; set; }
        public string note { get; set; }
        public int quantity { get; set; }
        public decimal total_price { get; set; }
        public string status { get; set; }
        public bool checkedBox { get; set; }
        public FoodOrder()
        {

        }
        public FoodOrder(int food_id, int restaurant_id, string food_name, decimal price, string photo, string note, int quantity, string status, bool checkedBox, string employee_name)
        {
            this.food_id = food_id;
            this.restaurant_id = restaurant_id;
            this.food_name = food_name;
            this.price = price;
            this.photo = photo;
            this.note = note;
            this.quantity = quantity;
            this.status = status;
            this.checkedBox = checkedBox;
            this.employee_name = employee_name;
        }
    }
}
