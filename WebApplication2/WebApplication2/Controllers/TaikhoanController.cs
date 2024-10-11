using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaikhoanController : ControllerBase
    {
        private IConfiguration _configuration;
        public TaikhoanController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetTaikhoan")]
        public JsonResult Getsanpham()
        {
            string query = "select * from Taikhoan";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetTaikhoanById")]
        public JsonResult GetNoteById(int id)
        {
            string query = "SELECT * FROM dbo.Taikhoan WHERE Id = @Id";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        [Route("AddTaikhoan")]
        public JsonResult AddTaikhoan([FromForm] string ten, [FromForm] string username, [FromForm] string password, [FromForm] string email, [FromForm] string phanquyen, [FromForm] DateTime thoigian)
        {
            string query = @"INSERT INTO dbo.Taikhoan (ten, username, password, email, phanquyen, thoigian) 
                     VALUES (@ten, @username, @password, @email, @phanquyen, @thoigian)";

            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");

            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ten", ten);
                    myCommand.Parameters.AddWithValue("@username", username);
                    myCommand.Parameters.AddWithValue("@password", password);
                    myCommand.Parameters.AddWithValue("@email", email);
                    myCommand.Parameters.AddWithValue("@phanquyen", phanquyen);
                    myCommand.Parameters.AddWithValue("@thoigian", thoigian);

                    // Thực thi câu lệnh INSERT
                    myCommand.ExecuteNonQuery();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpDelete]
        [Route("DeleteTaikhoan")]
        public JsonResult DeleteTaikhoan([FromForm] long id)
        {
            string query = "DELETE FROM dbo.Taikhoan WHERE id = @id";
            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");

            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);

                    // Thực thi câu lệnh DELETE
                    myCommand.ExecuteNonQuery();
                }
            }
            return new JsonResult("Deleted Successfully");
        }

        [HttpPut]
        [Route("UpdateTaikhoan")]
        public JsonResult UpdateTaikhoan([FromForm] long id, [FromForm] string ten, [FromForm] string username, [FromForm] string password, [FromForm] string email, [FromForm] string phanquyen, [FromForm] DateTime thoigian)
        {
            string query = @"UPDATE dbo.Taikhoan 
                     SET ten = @ten, username = @username, password = @password, 
                         email = @email, phanquyen = @phanquyen, thoigian = @thoigian
                     WHERE id = @id";

            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");

            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myCommand.Parameters.AddWithValue("@ten", ten);
                    myCommand.Parameters.AddWithValue("@username", username);
                    myCommand.Parameters.AddWithValue("@password", password);
                    myCommand.Parameters.AddWithValue("@email", email);
                    myCommand.Parameters.AddWithValue("@phanquyen", phanquyen);
                    myCommand.Parameters.AddWithValue("@thoigian", thoigian);

                    // Thực thi câu lệnh UPDATE
                    myCommand.ExecuteNonQuery();
                }
            }
            return new JsonResult("Updated Successfully");
        }

    }
}
