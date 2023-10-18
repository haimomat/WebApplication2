using Newtonsoft.Json;
using OnlineFood.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {

            return View();
        }
        [System.Web.Http.HttpGet]
        public List<Employee> Get()
        {
            string sqlCmd = "select * from Employee";
            DataSet ds = ConnectionString(sqlCmd);
            List<Employee> listEmployee = new List<Employee>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Employee newEmployee = new Employee();
                newEmployee.employee_id = row["employee_id"] != null ? int.Parse(row["employee_id"].ToString()) : 0; 
                newEmployee.full_name = row["full_name"] != null ? row["full_name"].ToString() : "";
                newEmployee.phone_number = row["phone_number"] != null ? row["phone_number"].ToString() : "";
                newEmployee.email = row["email"] != null ? row["email"].ToString() : "";
                newEmployee.dateOfBirth = row["dateOfBirth"] != null ? Convert.ToDateTime(row["dateOfBirth"].ToString()) : DateTime.Now;
                newEmployee.profile_photo = row["profile_photo"] != null ? row["profile_photo"].ToString() : "";
                newEmployee.password = row["password"] != null ? row["password"].ToString() : "";
                listEmployee.Add(newEmployee);
            }
            return listEmployee;
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<string> login(string userName, string pass)
        {
            ApiResponse<Employee> result;
            try
            {
                Employee emp;
                List<Employee> listEmployee = Get();
                emp = listEmployee.FirstOrDefault(x => x.full_name == userName && x.password == pass);
                if (emp != null)
                {
                    result = new ApiResponse<Employee>(System.Net.HttpStatusCode.OK, "Success", emp);
                }
                else
                    result = new ApiResponse<Employee>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Employee>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
        public DataSet ConnectionString(string sqlCmd){
            SqlConnection strConnect = new SqlConnection();
            DataSet ds = new DataSet();
            String connectionStr = "Data Source=MSI;Database=IchiisoftLunch;Trusted_Connection=True";
            strConnect.ConnectionString = connectionStr;
            strConnect.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, strConnect);
            da.Fill(ds);
            strConnect.Close();
            return ds;
        }
        public virtual async Task<string> GetAll()
        {
            ApiResponse<List<Employee>> result;
            try
            {
                List<Employee> listEmployee = Get();
                if (listEmployee != null)
                {
                    result = new ApiResponse<List<Employee>>(System.Net.HttpStatusCode.OK, "Success", listEmployee);
                }
                else
                    result = new ApiResponse<List<Employee>>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);
            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Employee>>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
        [System.Web.Http.HttpPost]
        public virtual async Task<string> CreateNew(Employee emp)
        {
            ApiResponse<Employee> result;
            try
            {
                SqlConnection strConnect = new SqlConnection();
                SqlCommand str = new SqlCommand();
                String connectionStr = "Data Source=MSI;Database=IchiisoftLunch;Trusted_Connection=True";
                strConnect.ConnectionString = connectionStr;
                str.Connection = strConnect;
                strConnect.Open();
                str.CommandText = "SPR_Employee_Add";
                str.CommandType = CommandType.StoredProcedure;
                str.Parameters.Add("full_name", SqlDbType.NVarChar).Value = emp.full_name;
                str.Parameters.Add("email", SqlDbType.NVarChar).Value = emp.email;
                str.Parameters.Add("phone_number", SqlDbType.NVarChar).Value = emp.phone_number;
                str.Parameters.Add("dateOfBirth", SqlDbType.DateTime).Value = emp.dateOfBirth;
                str.ExecuteNonQuery();
                strConnect.Close();
                if (emp != null)
                {
                    result = new ApiResponse<Employee>(System.Net.HttpStatusCode.OK, "Success", emp);
                }
                else
                    result = new ApiResponse<Employee>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Employee>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
    }
    
}