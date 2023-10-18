using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Controllers;
using OnlineFood.Core.Domain;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace WebApplication2.Controllers
{

    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }
        [System.Web.Http.HttpGet]
        public virtual async Task<string> GetAll()
        {
            ApiResponse<List<Restaurant>> result;
            try
            {
                var empCtrl = new EmployeeController();
                string sqlCmd = "select * from Restaurant";
                DataSet ds = empCtrl.ConnectionString(sqlCmd);
                List<Restaurant> listRestaurant = new List<Restaurant>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Restaurant newRestaurant = new Restaurant();
                    newRestaurant.restaurant_id = row["restaurant_id"] != null ? int.Parse(row["restaurant_id"].ToString()) : 0;
                    newRestaurant.restaurant_name = row["restaurant_name"] != null ? row["restaurant_name"].ToString() : "";
                    newRestaurant.address = row["address"] != null ? row["address"].ToString() : "";
                    newRestaurant.phone_number = row["phone_number"] != null ? row["phone_number"].ToString() : "";
                    newRestaurant.bank_account = row["bank_account"] != null ? row["bank_account"].ToString() : "";
                    newRestaurant.bank_name = row["bank_name"] != null ? row["bank_name"].ToString() : "";
                    newRestaurant.qr_code = row["qr_code"] != null ? row["qr_code"].ToString() : "";
                    newRestaurant.photo = row["photo"] != null ? row["photo"].ToString() : "";
                    listRestaurant.Add(newRestaurant);
                }
                /*Restaurant res;
                Random rdm = new Random();
                int rdmNum = rdm.Next(listRestaurant.Count);
                res = listRestaurant[rdmNum];*/
                if (listRestaurant != null)
                {
                    result = new ApiResponse<List<Restaurant>>(System.Net.HttpStatusCode.OK, "Success", listRestaurant);
                }
                else
                    result = new ApiResponse<List<Restaurant>>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Restaurant>>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
        public virtual async Task<string> GetByRestaurantId(int restaurant_id)
        {
            ApiResponse<Restaurant> result;
            try
            {
                var empCtrl = new EmployeeController();
                string sqlCmd = string.Format("select * from Restaurant where restaurant_id = {0}", restaurant_id);
                DataSet ds = empCtrl.ConnectionString(sqlCmd);
                Restaurant newRestaurant = new Restaurant();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    newRestaurant.restaurant_id = row["restaurant_id"] != null ? int.Parse(row["restaurant_id"].ToString()) : 0;
                    newRestaurant.restaurant_name = row["restaurant_name"] != null ? row["restaurant_name"].ToString() : "";
                    newRestaurant.address = row["address"] != null ? row["address"].ToString() : "";
                    newRestaurant.phone_number = row["phone_number"] != null ? row["phone_number"].ToString() : "";
                    newRestaurant.bank_account = row["bank_account"] != null ? row["bank_account"].ToString() : "";
                    newRestaurant.bank_name = row["bank_name"] != null ? row["bank_name"].ToString() : "";
                    newRestaurant.qr_code = row["qr_code"] != null ? row["qr_code"].ToString() : "";
                    newRestaurant.photo = row["photo"] != null ? row["photo"].ToString() : "";
                }
                if (newRestaurant != null)
                {
                    result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.OK, "Success", newRestaurant);
                }
                else
                    result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
        [System.Web.Http.HttpPost]
        public virtual async Task<string> CreateNew(Restaurant emp)
        {
            ApiResponse<Restaurant> result;
            try
            {
                SqlConnection strConnect = new SqlConnection();
                SqlCommand str = new SqlCommand();
                String connectionStr = "Data Source=MSI;Database=IchiisoftLunch;Trusted_Connection=True";
                strConnect.ConnectionString = connectionStr;
                str.Connection = strConnect;
                strConnect.Open();
                str.CommandText = "SPR_Restaurant_Add";
                str.CommandType = CommandType.StoredProcedure;
                str.Parameters.Add("restaurant_name", SqlDbType.NVarChar).Value = emp.restaurant_name;
                str.Parameters.Add("address", SqlDbType.NVarChar).Value = emp.address;
                str.Parameters.Add("phone_number", SqlDbType.NVarChar).Value = emp.phone_number;
                str.Parameters.Add("bank_account", SqlDbType.NVarChar).Value = emp.bank_account;
                str.Parameters.Add("bank_name", SqlDbType.NVarChar).Value = emp.bank_name;
                str.Parameters.Add("qr_code", SqlDbType.NVarChar).Value = emp.qr_code;
                str.Parameters.Add("photo", SqlDbType.NVarChar).Value = emp.photo;
                str.ExecuteNonQuery();
                strConnect.Close();
                if (emp != null)
                {
                    result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.OK, "Success", emp);
                }
                else
                    result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
        [System.Web.Http.HttpPut]
        public virtual async Task<string> Update(Restaurant emp)
        {
            ApiResponse<Restaurant> result;
            try
            {
                SqlConnection strConnect = new SqlConnection();
                SqlCommand str = new SqlCommand();
                String connectionStr = "Data Source=MSI;Database=IchiisoftLunch;Trusted_Connection=True";
                strConnect.ConnectionString = connectionStr;
                str.Connection = strConnect;
                strConnect.Open();
                str.CommandText = "SPR_Restaurant_Update";
                str.CommandType = CommandType.StoredProcedure;
                str.Parameters.Add("restaurant_id", SqlDbType.Int).Value = emp.restaurant_id;
                str.Parameters.Add("restaurant_name", SqlDbType.NVarChar).Value = emp.restaurant_name;
                str.Parameters.Add("address", SqlDbType.NVarChar).Value = emp.address;
                str.Parameters.Add("phone_number", SqlDbType.NVarChar).Value = emp.phone_number;
                str.Parameters.Add("bank_account", SqlDbType.NVarChar).Value = emp.bank_account;
                str.Parameters.Add("bank_name", SqlDbType.NVarChar).Value = emp.bank_name;
                str.Parameters.Add("qr_code", SqlDbType.NVarChar).Value = emp.qr_code;
                str.Parameters.Add("photo", SqlDbType.NVarChar).Value = emp.photo;
                str.ExecuteNonQuery();
                strConnect.Close();
                if (emp != null)
                {
                    result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.OK, "Success", emp);
                }
                else
                    result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
        [System.Web.Http.HttpDelete]
        public virtual async Task<string> Delete(Restaurant emp)
        {
            ApiResponse<Restaurant> result;
            try
            {
                SqlConnection strConnect = new SqlConnection();
                SqlCommand str = new SqlCommand();
                String connectionStr = "Data Source=MSI;Database=IchiisoftLunch;Trusted_Connection=True";
                strConnect.ConnectionString = connectionStr;
                str.Connection = strConnect;
                strConnect.Open();
                str.CommandText = "proc_delete";
                str.CommandType = CommandType.StoredProcedure;
                str.Parameters.Add("PrimaryKey", SqlDbType.Int).Value = emp.restaurant_id;
                str.ExecuteNonQuery();
                if (emp != null)
                {
                    result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.OK, "Success", emp);
                }
                else
                    result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Restaurant>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
        }
}    