using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFood.Core.Domain
{
    public class Employee
    {
        public string createBy { get; set; }
        public DateTime createDate { get; set; }
        public string updateBy { get; set; }
        public DateTime updateDate { get; set; }
        public int employee_id { get; set; }
        public string full_name { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string profile_photo { get; set; }
        public string password { get; set; }
        public Employee()
        {
        }
        public Employee(int employee_id, string full_name, string phone_number, string email, DateTime dateOfBirth, string profile_photo, string password, string createBy, DateTime createDate, string updateBy, DateTime updateDate)
        {
            this.employee_id = employee_id;
            this.full_name = full_name;
            this.phone_number = phone_number;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
            this.profile_photo = profile_photo;
            this.password = password;
            this.createBy = createBy;
            this.createDate = createDate;
            this.updateBy = updateBy;
            this.updateDate = updateDate;
        }
    }
}
