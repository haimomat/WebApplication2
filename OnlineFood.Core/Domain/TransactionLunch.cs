using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFood.Core.Domain
{
    public class TransactionLunch
    {
        public string createBy { get; set; }
        public DateTime createDate { get; set; }
        public string updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public string transaction_id { get; set; }
        public string statusOrder { get; set; }
        public string statusPayment { get; set; }

        public int total_quantity { get; set; }
        public int employee_id { get; set; }
        public string full_name { get; set; }
        public DateTime order_date { get; set; }
        public decimal total_price { get; set; }
        public string employee_ordered_name { get; set; }
        public TransactionLunch() { }
        public TransactionLunch(string transaction_id,string statusOrder, string statusPayment, int total_quantity, int employee_id, string full_name, DateTime order_date, decimal total_price, string employee_ordered_name, string createBy, DateTime createDate, string updateBy, DateTime updateDate)
        {
            this.transaction_id = transaction_id;
            this.statusOrder = statusOrder;
            this.statusPayment = statusPayment;
            this.total_quantity = total_quantity;
            this.employee_id = employee_id;
            this.full_name = full_name;
            this.order_date = order_date;
            this.total_price = total_price;
            this.employee_ordered_name = employee_ordered_name;
            this.createBy = createBy;
            this.createDate = createDate;
            this.updateBy = updateBy;
            this.updateDate = updateDate;
        }
    }
}
