using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Helpers
{
    public class SQLHelper
    {
        string sqlConnect = string.Empty;
        public SQLHelper()
        {
            sqlConnect = "Data Source=MSI;Database=IchiisoftLunch;Trusted_Connection=True";
        }
        /// <summary>
        /// Lấy data
        /// </summary>
        public DataSet getData(string commandText)
        {
            try
            {
                SqlConnection strConnect = new SqlConnection();
                DataSet ds = new DataSet();
                strConnect.ConnectionString = sqlConnect;
                strConnect.Open();
                SqlDataAdapter da = new SqlDataAdapter(commandText, sqlConnect);
                da.Fill(ds);
                strConnect.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Các hàm thêm, sửa, xóa dữ liệu
        /// </summary>
        public int ExecuteData(string commandText, List<Parameter> parameters)
        {
            int result = 0;
            try
            {
                SqlConnection strConnect = new SqlConnection(sqlConnect);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = strConnect;
                 
                foreach(var pr in parameters)
                {
                    cmd.Parameters.Add(pr.Name, pr.DataType).Value = pr.Value;
                }
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = -1;
                throw;
            }
            return result;
        }
    }
    public class Parameter
    {
        public string Name { get; set; }
        public SqlDbType DataType { get; set; }
        public string Value { get; set; }
    }
}