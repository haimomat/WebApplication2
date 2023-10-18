using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFood.Core.Domain
{
    public class PaymentDetail
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

        public int transaction_detail_id { get; set; }
        public string transaction_id { get; set; }
        public int restaurant_id { get; set; }
        public int employee_id { get; set; }
        public string full_name { get; set; }
        public DateTime order_date { get; set; }
        public string employee_ordered_name { get; set; }
        public PaymentDetail() { }
        public PaymentDetail(string customerName, string food_name, decimal price, int quantity, int total_quantity, int food_id, string note, decimal total_price, string statusOrder, string statusPayment, string employee_ordered_name, DateTime order_date, string full_name, int employee_id, int restaurant_id, string transaction_id, int transaction_detail_id, string createBy, DateTime createDate, string updateBy, DateTime updateDate)
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
            this.employee_ordered_name = employee_ordered_name;
            this.order_date = order_date;
            this.full_name = full_name;
            this.employee_id = employee_id;
            this.restaurant_id = restaurant_id;
            this.transaction_id = transaction_id;
            this.transaction_detail_id = transaction_detail_id;
            this.createBy = createBy;
            this.createDate = createDate;
            this.updateBy = updateBy;
            this.updateDate = updateDate;
        }
    }
}
