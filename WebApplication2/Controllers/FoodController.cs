using Newtonsoft.Json;
using OnlineFood.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {
            return View();
        }
        [System.Web.Http.HttpGet]
        public virtual async Task<string> GetAll()
        {
            ApiResponse<List<Food>> result;
            try
            {
                var empCtrl = new EmployeeController();
                string sqlCmd = "select * from Food";
                DataSet ds = empCtrl.ConnectionString(sqlCmd);
                List<Food> listFood = new List<Food>();
                Food newFood = new Food();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    newFood.food_id = row["food_id"] != null ? int.Parse(row["food_id"].ToString()) : 0;
                    newFood.restaurant_id = row["restaurant_id"] != null ? int.Parse(row["restaurant_id"].ToString()) : 0;
                    newFood.food_name = row["food_name"] != null ? row["food_name"].ToString() : "";
                    newFood.price = row["price"] != null ? Convert.ToDecimal(row["price"].ToString()) : 0;
                    newFood.photo = row["photo"] != null ? row["photo"].ToString() : "";
                    newFood.note = row["note"] != null ? row["note"].ToString() : "";
                    listFood.Add(newFood);
                }
                if (listFood != null)
                {
                    result = new ApiResponse<List<Food>>(System.Net.HttpStatusCode.OK, "Success", listFood);
                }
                else
                    result = new ApiResponse<List<Food>>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Food>>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<string> GetByRestaurantId(int restaurant_id)
        {
            ApiResponse<List<Food>> result;
            try
            {
                var empCtrl = new EmployeeController();
                string sqlCmd = string.Format("select * from Food where restaurant_id = {0}", restaurant_id);
                DataSet ds = empCtrl.ConnectionString(sqlCmd);
                List<Food> listFood = new List<Food>();          
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                    Food newFood = new Food();
                    newFood.food_id = row["food_id"] != null ? int.Parse(row["food_id"].ToString()) : 0;
                    newFood.restaurant_id = row["restaurant_id"] != null ? int.Parse(row["restaurant_id"].ToString()) : 0;
                    newFood.food_name = row["food_name"] != null ? row["food_name"].ToString() : "";
                    newFood.price = row["price"] != null ? Convert.ToDecimal(row["price"].ToString()) : 0;
                    newFood.photo = row["photo"] != null ? row["photo"].ToString() : "";
                    newFood.note = row["note"] != null ? row["note"].ToString() : "";
                    listFood.Add(newFood);
                    }
                if (listFood != null)
                {
                    result = new ApiResponse<List<Food>>(System.Net.HttpStatusCode.OK, "Success", listFood);
                }
                else
                    result = new ApiResponse<List<Food>>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Food>>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
    }
    
}