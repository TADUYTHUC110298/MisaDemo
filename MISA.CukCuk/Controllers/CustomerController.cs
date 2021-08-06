using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //GET api/<CustomerController>
        [HttpGet("{id}")]
        [Route("{customerCode}")]
        public object Get(string employeecode)
        {
            var customers = new List<CustomerController>();
            string connectionString = "Server=tenserver;Database=tendb;UserName=sa;Password=123456";
            //khởi tạo sqlConnection
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //Khởi tạo sqlCommand để thao tác với CSDL
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "USP_DEMOMISA_CUD";
            sqlCommand.Parameters.AddWithValue("@paramsp", Guid.NewGuid());
            //Mở kết nối vs db
            sqlConnection.Open();
            //Làm việc với db
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //Xử lý dữ liệu trả về
            while (sqlDataReader.Read())
            {
                var customer = new CustomerController();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột đang đọc
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị của cell đang đọc
                    var value = sqlDataReader.GetValue(i);
                    var proprety = customer.GetType().GetProperty(colName);
                    // Chỉ thực hiện gán khi proprety có giá trị(giá trị null trong db thì bỏ qua)
                    if (proprety != null && value != DBNull.Value)
                    {
                        proprety.SetValue(customer, value);
                    }
                }

                // Thêm đối tượng khách hàng vừa build được vào list
                customers.Add(customer);
            }
            //Đóng kết nối
            sqlCommand.Clone();
            return customers;
        }
         

        // POST api/<CustomerController>
        [HttpPost]
        public bool Post([FromBody] CustomerController customer)
        {
            return true;
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
