using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFood.Core.Domain
{
     public class Restaurant
    {
        public string createBy { get; set; }
        public DateTime createDate { get; set; }
        public string updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public int restaurant_id { get; set; }
        public string restaurant_name { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public string bank_account { get; set; }
        public string bank_name { get; set; }
        public string qr_code { get; set; }
        public string photo { get; set; }
        public Restaurant()
        {

        }
        public Restaurant(int restaurant_id, string restaurant_name, string address, string phone_number, string bank_account, string bank_name, string qr_code, string createBy, DateTime createDate, string updateBy, DateTime updateDate, string photo)
        {
            this.restaurant_id = restaurant_id;
            this.restaurant_name = restaurant_name;
            this.address = address;
            this.phone_number = phone_number;
            this.bank_account = bank_account;
            this.bank_name = bank_name;
            this.qr_code = qr_code;
            this.createBy = createBy;
            this.createDate = createDate;
            this.updateBy = updateBy;
            this.updateDate = updateDate;
            this.photo = photo;
        }
    }
}
