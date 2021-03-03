using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<StudentViewModel> lst = new List<StudentViewModel>();

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True; Database=AchsDB");

            SqlCommand cmd = new SqlCommand("SELECT * FROM tblStudent", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader(); // data reader

            while (dr.Read())
            {
                lst.Add(new StudentViewModel()
                {
                    StudentId = (int)dr["StudentId"],
                    FullName = (string)dr["FullName"],
                    Email = (string)dr["Email"],
                    Phone = (string)dr["Phone"],
                });

            }
            dr.Close();
            conn.Close();
            return View(lst);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel stu)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True; Database=AchsDB");
            SqlCommand cmd = new SqlCommand("INSERT INTO tblStudent VALUES(@a, @b, @c)", conn);
            cmd.Parameters.AddWithValue("@a", stu.FullName);
            cmd.Parameters.AddWithValue("@b", stu.Email);
            cmd.Parameters.AddWithValue("@c", stu.Phone);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            ViewBag.Message = "Student info inserted successfully.";

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentViewModel student = new StudentViewModel();

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True; Database=AchsDB");

            SqlCommand cmd = new SqlCommand("SELECT * FROM tblStudent WHERE StudentId=@a", conn);
            cmd.Parameters.AddWithValue("@a", id); // passing value of @a paramterer in the SqlCommand
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader(); // data reader

            // adding the property readed from db to student obj
            if (dr.Read()) // if there is data
            {
                student.StudentId = (int)dr["StudentId"];
                student.FullName = (string)dr["FullName"];
                student.Email = (string)dr["Email"];
                student.Phone = (string)dr["Phone"];
            }
            dr.Close();
            conn.Close();

            return View(student);
        }


        [HttpPost]
        public IActionResult Edit(StudentViewModel stu)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True; Database=AchsDB");
            SqlCommand cmd = new SqlCommand("UPDATE tblStudent SET FullName=@a, Email=@b, Phone=@c WHERE StudentId=@d", conn);
            cmd.Parameters.AddWithValue("@a", stu.FullName);
            cmd.Parameters.AddWithValue("@b", stu.Email);
            cmd.Parameters.AddWithValue("@c", stu.Phone);
            cmd.Parameters.AddWithValue("@d", stu.StudentId);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            ViewBag.Message = "Student info updated successfully.";

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            StudentViewModel student = new StudentViewModel();

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True; Database=AchsDB");

            SqlCommand cmd = new SqlCommand("SELECT * FROM tblStudent WHERE StudentId=@a", conn);
            cmd.Parameters.AddWithValue("@a", id); // passing value of @a paramterer in the SqlCommand
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader(); // data reader

            // adding the property readed from db to student obj
            if (dr.Read()) // if there is data
            {
                student.StudentId = (int)dr["StudentId"];
                student.FullName = (string)dr["FullName"];
                student.Email = (string)dr["Email"];
                student.Phone = (string)dr["Phone"];
            }
            dr.Close();
            conn.Close();

            return View(student);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete_Post(int id)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True; Database=AchsDB");
            SqlCommand cmd = new SqlCommand("DELETE FROM tblStudent WHERE StudentId=@a", conn);
            cmd.Parameters.AddWithValue("@a", id);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            ViewBag.Message = "Student info deleted successfully.";

            return RedirectToAction("Index");
        }
    }
}
