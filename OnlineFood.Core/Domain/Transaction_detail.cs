using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFood.Core.Domain
{
    public class Transaction_detail
    {
        public string createBy { get; set; }
        public DateTime createDate { get; set; }
        public string updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public int transaction_detail_id { get; set; }
        public string transaction_id { get; set; }
        public int restaurant_id { get; set; }
        public int food_id { get; set; }
        public string food_name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string note { get; set; }
        public Transaction_detail() { }
        public Transaction_detail(int transaction_detail_id, string transaction_id, int restaurant_id, int food_id, string food_name, int quantity, decimal price, string note, string createBy, DateTime createDate, string updateBy, DateTime updateDate) {
            this.transaction_detail_id = transaction_detail_id;
            this.transaction_id = transaction_id;
            this.restaurant_id = restaurant_id;
            this.food_id = food_id;
            this.food_name = food_name;
            this.quantity = quantity;
            this.price = price;
            this.note = note;
            this.createBy = createBy;
            this.createDate = createDate;
            this.updateBy = updateBy;
            this.updateDate = updateDate;
        }
    }
}
