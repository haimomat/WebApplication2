using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFood.Core.Domain
{
    public class Food
    {
        public string createBy { get; set; }
        public DateTime createDate { get; set; }
        public string updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public int food_id { get; set; }
        public int restaurant_id { get; set; }
        public string food_name { get; set; }
        public decimal price { get; set; }
        public string photo { get; set; }
        public string note { get; set; }
        public Food()
        {

        }
        public Food(int food_id, int restaurant_id, string food_name, decimal price, string photo, string note, string createBy, DateTime createDate, string updateBy, DateTime updateDate)
        {
            this.food_id = food_id;
            this.restaurant_id = restaurant_id;
            this.food_name = food_name;
            this.price = price;
            this.photo = photo;
            this.note = note;
            this.createBy = createBy;
            this.createDate = createDate;
            this.updateBy = updateBy;
            this.updateDate = updateDate;
        }
    }
}
