using Newtonsoft.Json;
using OnlineFood.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace WebApplication2.Controllers
{
    public class TransactionLunchController : Controller
    {
        // GET: TransactionLunch
        public ActionResult Index()
        {
            return View();
        }
        //PUT: TransactionLunch
        [System.Web.Http.HttpPost]
        public virtual async Task<string> CreateNew(TransactionLunch trans)
        {
            ApiResponse<TransactionLunch> result;
            try
            {
                SqlConnection strConnect = new SqlConnection();
                SqlCommand str = new SqlCommand();
                String connectionStr = "Data Source=MSI;Database=IchiisoftLunch;Trusted_Connection=True";
                strConnect.ConnectionString = connectionStr;
                str.Connection = strConnect;
                strConnect.Open();
                str.CommandText = "SPR_TransactionLunch_Add";
                str.CommandType = CommandType.StoredProcedure;
                str.Parameters.Add("@transaction_id", SqlDbType.NVarChar).Value = trans.transaction_id;
                str.Parameters.Add("@statusOrder", SqlDbType.NVarChar).Value = trans.statusOrder;
                str.Parameters.Add("@employee_id", SqlDbType.Int).Value = trans.employee_id;
                str.Parameters.Add("@full_name", SqlDbType.NVarChar).Value = trans.full_name;
                str.Parameters.Add("@order_date", SqlDbType.DateTime).Value = trans.order_date;
                str.Parameters.Add("@employee_ordered_name", SqlDbType.NVarChar).Value = trans.employee_ordered_name;
                str.Parameters.Add("@total_price", SqlDbType.Decimal).Value = trans.total_price;
                str.Parameters.Add("@total_quantity", SqlDbType.Int).Value = trans.total_quantity;
                str.Parameters.Add("@createBy", SqlDbType.NVarChar).Value = trans.createBy;
                str.Parameters.Add("@createDate", SqlDbType.NVarChar).Value = trans.createDate;
                str.Parameters.Add("@updateBy", SqlDbType.NVarChar).Value = trans.updateBy;
                str.Parameters.Add("@updateDate", SqlDbType.NVarChar).Value = trans.createDate;
                str.Parameters.Add("@statusPayment", SqlDbType.NVarChar).Value = trans.statusPayment;
                str.ExecuteNonQuery();
                strConnect.Close();
                if (trans != null)
                {
                    result = new ApiResponse<TransactionLunch>(System.Net.HttpStatusCode.OK, "Success", trans);
               }
                else
                    result = new ApiResponse<TransactionLunch>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);            
            }
            catch (Exception ex)
            {
                result = new ApiResponse<TransactionLunch>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
        [System.Web.Http.HttpGet]
        public virtual async Task<string> GetAll()
        {
            ApiResponse<List<TransactionLunch>> result;
            try
            {
                var empCtrl = new EmployeeController();
                string sqlCmd = "select * from TransactionLunch";
                DataSet ds = empCtrl.ConnectionString(sqlCmd);
                List<TransactionLunch> listTransactionLunch = new List<TransactionLunch>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TransactionLunch newTransactionLunch = new TransactionLunch();
                    newTransactionLunch.transaction_id = row["transaction_id"] != null ? row["transaction_id"].ToString() : ""; 
                    newTransactionLunch.statusOrder = row["statusOrder"] != null ? row["statusOrder"].ToString() : ""; 
                    newTransactionLunch.statusPayment = row["statusPayment"] != null ? row["statusPayment"].ToString() : "";
                    newTransactionLunch.employee_id = row["employee_id"] != null ? int.Parse(row["employee_id"].ToString()) : 0;
                    newTransactionLunch.full_name = row["full_name"] != null ? row["full_name"].ToString() : "";
                    newTransactionLunch.order_date = row["order_date"] != null ? Convert.ToDateTime(row["order_date"].ToString()) : DateTime.Now;
                    newTransactionLunch.total_price = row["total_price"] != null ? Convert.ToDecimal(row["total_price"].ToString()) : 0;
                    newTransactionLunch.total_quantity = row["total_quantity"] != null ? int.Parse(row["employee_id"].ToString()) : 0;
                    newTransactionLunch.employee_ordered_name = row["employee_ordered_name"] != null ? row["employee_ordered_name"].ToString() : "";
                    newTransactionLunch.createBy = row["createBy"] != null ? row["createBy"].ToString() : "";
                    newTransactionLunch.createDate = row["createDate"] != null ? Convert.ToDateTime(row["createDate"].ToString()) : DateTime.Now;
                    newTransactionLunch.updateBy = row["updateBy"] != null ? row["updateBy"].ToString() : "";
                    newTransactionLunch.updateDate = row["updateDate"] != null ? Convert.ToDateTime(row["updateDate"].ToString()) : DateTime.Now;
                    listTransactionLunch.Add(newTransactionLunch);
                }
                if (listTransactionLunch != null)
                {
                    result = new ApiResponse<List<TransactionLunch>>(System.Net.HttpStatusCode.OK, "Success", listTransactionLunch);
                }
                else
                    result = new ApiResponse<List<TransactionLunch>>(System.Net.HttpStatusCode.NoContent, "Not found data.", null);

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<TransactionLunch>>(System.Net.HttpStatusCode.ExpectationFailed, ex.Message, null);
            }
            return JsonConvert.SerializeObject(result);
        }
    }
}