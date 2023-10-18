using Newtonsoft.Json;
using OnlineFood.Core.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace WebApplication2.Controllers
{
    public class Transaction_detailController : Controller
    {
        // GET: Transaction_detail
        public ActionResult Index()
        {
            return View();
        }
        [System.Web.Http.HttpGet]
        public virtual async Task<string> GetAll()
        {
            ApiResponse<List<Transaction_detail>> result;
            try
            {
                var empCtrl = new EmployeeController();
                string sqlCmd = "select * from Transaction_detail";
                DataSet ds = empCtrl.ConnectionString(sqlCmd);
                List<Transaction_detail> listTransaction_detail = new List<Transaction_detail>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Transaction_detail newTransaction_detail = new Transaction_detail();
                    newTransaction_detail.transaction_detail_id = (int)row["transaction_detail_id"];
                    newTransaction_detail.transaction_id = (string)row["transaction_id"];
                    newTransaction_detail.restaurant_id = (int)row["restaurant_id"];
                    newTransaction_detail.food_id = (int)row["food_id"];
                    newTransaction_detail.food_name = (string)row["food_name"];
                    newTransaction_detail.quantity = (int)row["quantity"];
                    newTransaction_detail.price = (decimal)row["price"];
                    newTransaction_detail.note = (string)row["note"];
                    newTransaction_detail.createBy = (string)row["createBy"];
                    newTransaction_detail.createDate = (DateTime)row["createDate"];
                    newTransaction_detail.updateBy = (string)row["updateBy"];
                    newTransaction_detail.createDate = (DateTime)row["createDate"];
                    listTransaction_detail.Add(newTransaction_detail);
                }
                if (listTransaction_detail != null)
                {
                    result = new ApiResponse<List<Transaction_detail>>(System.Net.HttpStatusCode.OK, "Success", listTransaction_detail);
                }
                else
                    result = new ApiResponse<List<Transaction_detail>>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Transaction_detail>>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
            }
        //Post Method
            [System.Web.Http.HttpPost]
        public virtual async Task<string> CreateNew(Transaction_detail trans)
        {
            ApiResponse<Transaction_detail> result;
            try
            {
                SqlConnection strConnect = new SqlConnection();
                SqlCommand str = new SqlCommand();
                SqlCommand strLunch = new SqlCommand();
                String connectionStr = "Data Source=MSI;Database=IchiisoftLunch;Trusted_Connection=True"; 
                strConnect.ConnectionString = connectionStr;
                str.Connection = strConnect;
                strConnect.Open();
                str.CommandText = "SPR_TransactionDetail_Add";
                str.CommandType = CommandType.StoredProcedure;
                strLunch.CommandText = "SPR_TransactionLunch_Add";
                strLunch.CommandType = CommandType.StoredProcedure;
                str.Parameters.Add("@transaction_id", SqlDbType.NVarChar).Value = trans.transaction_id;
                str.Parameters.Add("@restaurant_id", SqlDbType.Int).Value = trans.restaurant_id;
                str.Parameters.Add("@food_id", SqlDbType.Int).Value = trans.food_id;
                str.Parameters.Add("@food_name", SqlDbType.NVarChar).Value = trans.food_name;
                str.Parameters.Add("@quantity", SqlDbType.Int).Value = trans.quantity;
                str.Parameters.Add("@price", SqlDbType.Decimal).Value = trans.price;
                str.Parameters.Add("@note", SqlDbType.NVarChar).Value = trans.note;
                str.Parameters.Add("@createBy", SqlDbType.NVarChar).Value = trans.createBy;
                str.Parameters.Add("@createDate", SqlDbType.DateTime).Value = trans.createDate;
                str.Parameters.Add("@updateBy", SqlDbType.NVarChar).Value = trans.updateBy;
                str.Parameters.Add("@updateDate", SqlDbType.NVarChar).Value = trans.createDate;
                str.ExecuteNonQuery();
                strConnect.Close();
                if (trans != null)
                {
                    result = new ApiResponse<Transaction_detail>(System.Net.HttpStatusCode.OK, "Success", trans);
                }
                else
                    result = new ApiResponse<Transaction_detail>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);
            }
            catch (Exception ex)
            {
                result = new ApiResponse<Transaction_detail>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
    }
}