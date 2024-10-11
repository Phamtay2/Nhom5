using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucController : ControllerBase
    {
        private IConfiguration _configuration;
        public DanhmucController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("Getdanhmuc")]
        public JsonResult Getdanhmuc()
        {
            string query = "select * from danhmuc";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource)) 
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))  
                {
                    myReader=myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet]
        [Route("GetdanhmucById")]
        public JsonResult GetNoteById(int id)
        {
            string query = "SELECT * FROM dbo.danhmuc WHERE Id = @Id";
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
        [Route("Adddanhmuc")]
        public JsonResult Adddanhmuc([FromForm] string tendm, [FromForm] int uutien, [FromForm] int hienthi, [FromForm] string ghichu)
        {
            string query = "insert into dbo.danhmuc (tendm, uutien, hienthi, ghichu) values (@tendm, @uutien, @hienthi, @ghichu)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@tendm", tendm);
                    myCommand.Parameters.AddWithValue("@uutien", uutien);
                    myCommand.Parameters.AddWithValue("@hienthi", hienthi);
                    myCommand.Parameters.AddWithValue("@ghichu", ghichu);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }


        [HttpPost]
        [Route("Updatedanhmuc")]
        public JsonResult UpdateNotes([FromForm] int id, [FromForm] string tendm, [FromForm] int uutien, [FromForm] int hienthi, [FromForm] string ghichu)
        {
            // Câu lệnh SQL để cập nhật name và description theo id
            string query = "UPDATE dbo.danhmuc SET tendm = @tendm, uutien = @uutien, hienthi = @hienthi, ghichu = @ghichu WHERE Id = @Id";

            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    // Thêm tham số cho câu lệnh SQL
                    myCommand.Parameters.AddWithValue("@Id", id);
                    myCommand.Parameters.AddWithValue("@tendm", tendm);
                    myCommand.Parameters.AddWithValue("@uutien", uutien);
                    myCommand.Parameters.AddWithValue("@hienthi", hienthi);
                    myCommand.Parameters.AddWithValue("@ghichu", ghichu);

                    // Thực hiện truy vấn và lấy dữ liệu
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete]
        [Route("Deletedanhmuc")]
        public JsonResult Deletedanhmuc(int id)
        {
            string query = "DELETE FROM dbo.danhmuc WHERE id = @id";
            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");

            try
            {
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
            catch (Exception ex)
            {
                // Bắt lỗi và trả về thông báo lỗi chi tiết
                return new JsonResult($"Error: {ex.Message}");
            }
        }

    }
}
