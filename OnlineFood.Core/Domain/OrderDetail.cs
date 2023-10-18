using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFood.Core.Domain
{
    public class OrderDetail
    {
        public string createBy { get; set; }
        public DateTime createDate { get; set; }
        public string updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public string customerName { get; set; }
        public string food_name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int total_quantity { get; set; }
        public int food_id { get; set; }
        public string note { get; set; }
        public decimal total_price { get; set; }
        public string statusOrder { get; set; }
        public string statusPayment { get; set; }
        public DateTime orderDate { get; set; }
        public OrderDetail() { }
        public OrderDetail(string customerName, string food_name, decimal price, int quantity, int total_quantity, int food_id, string note, decimal total_price, string statusOrder, string statusPayment, DateTime orderDate)
        {
            this.customerName = customerName;
            this.food_name = food_name;
            this.price = price;
            this.quantity = quantity;
            this.total_quantity = total_quantity;
            this.food_id = food_id;
            this.note = note;
            this.total_price = total_price;
            this.statusOrder = statusOrder;
            this.statusPayment = statusPayment;
            this.orderDate = orderDate;
        }
    }
}
