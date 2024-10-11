using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sanphamController : ControllerBase
    {
        private IConfiguration _configuration;
        public sanphamController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("Getsanpham")]
        public JsonResult Getsanpham()
        {
            string query = "select * from sanpham";
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
        [Route("GetsanphamById")]
        public JsonResult GetNoteById(int id)
        {
            string query = "SELECT * FROM dbo.sanpham WHERE Id = @Id";
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
        [Route("Addsanpham")]
        public JsonResult Addsanpham([FromForm] string masp, [FromForm] string tensp, [FromForm] string danhmuc, [FromForm] int gianhap, [FromForm] int giaban, [FromForm] int giakm, [FromForm] int soluong, [FromForm] int hienthi, [FromForm] DateTime thoigian, [FromForm] string mota)
        {
            string query = "INSERT INTO dbo.sanpham (masp, tensp, danhmuc, gianhap, giaban, giakm, soluong, hienthi, thoigian, mota) VALUES (@masp, @tensp, @danhmuc, @gianhap, @giaban, @giakm, @soluong, @hienthi, @thoigian, @mota)";
            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");

                using (SqlConnection myCon = new SqlConnection(sqlDatasource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@masp", masp);
                        myCommand.Parameters.AddWithValue("@tensp", tensp);
                        myCommand.Parameters.AddWithValue("@danhmuc", danhmuc);
                        myCommand.Parameters.AddWithValue("@gianhap", gianhap);
                        myCommand.Parameters.AddWithValue("@giaban", giaban);
                        myCommand.Parameters.AddWithValue("@giakm", giakm);
                        myCommand.Parameters.AddWithValue("@soluong", soluong);
                        myCommand.Parameters.AddWithValue("@hienthi", hienthi);
                        myCommand.Parameters.AddWithValue("@thoigian", thoigian);
                        myCommand.Parameters.AddWithValue("@mota", mota);

                        // Thực thi câu lệnh INSERT
                        myCommand.ExecuteNonQuery();
                    }
                }
                return new JsonResult("Added Successfully");
            
        }

        [HttpDelete]
        [Route("Deletesanpham")]
        public JsonResult Deletesanpham(int id)
        {
            string query = "DELETE FROM dbo.sanpham WHERE id = @id";
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

        [HttpPost]
        [Route("Updatesanpham")]
        public JsonResult Updatesanpham([FromForm] int id ,[FromForm]string masp, [FromForm] string tensp, [FromForm] string danhmuc, [FromForm] int gianhap, [FromForm] int giaban, [FromForm] int giakm, [FromForm] int soluong, [FromForm] int hienthi, [FromForm] DateTime thoigian, [FromForm] string mota)
        {
            string query = @"UPDATE dbo.sanpham 
                     SET masp = @masp ,tensp = @tensp, danhmuc = @danhmuc, gianhap = @gianhap, 
                         giaban = @giaban, giakm = @giakm, soluong = @soluong, 
                         hienthi = @hienthi, thoigian = @thoigian, mota = @mota
                     WHERE Id = @Id";

            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("QuanlybanhangCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);
                    myCommand.Parameters.AddWithValue("@masp", masp);
                    myCommand.Parameters.AddWithValue("@tensp", tensp);
                    myCommand.Parameters.AddWithValue("@danhmuc", danhmuc);
                    myCommand.Parameters.AddWithValue("@gianhap", gianhap);
                    myCommand.Parameters.AddWithValue("@giaban", giaban);
                    myCommand.Parameters.AddWithValue("@giakm", giakm);
                    myCommand.Parameters.AddWithValue("@soluong", soluong);
                    myCommand.Parameters.AddWithValue("@hienthi", hienthi);
                    myCommand.Parameters.AddWithValue("@thoigian", thoigian);
                    myCommand.Parameters.AddWithValue("@mota", mota);

                    // Thực thi câu lệnh UPDATE
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }


    }
}
