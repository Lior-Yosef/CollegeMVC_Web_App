using CollegeMVC_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollegeMVC_Web_App.Controllers.API
{
    public class StudentController : ApiController
    {
        string connctionString = "Data Source=LAPTOP-OT5IVM7S;Initial Catalog=CollegeDB;Integrated Security=True;Pooling=False";

        // GET: api/Student
        public IHttpActionResult Get()
        {
            List<Student> listStudent = GetAllStudent(connctionString);

            return Ok();
        }

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }


        public static List<Student> GetAllStudent(string connctionString)
        {


            using (SqlConnection conn = new SqlConnection(connctionString))
            {
                conn.Open();
                string query = @"SELECT * FROM Student";
                SqlCommand cmd = new SqlCommand(query, conn);
                var Data = cmd.ExecuteReader();

                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        Student.listStudent.Add(new Student(Data.GetString(1),
                                                            Data.GetString(2),
                                                            Data.GetDateTime(3),
                                                            Data.GetString(4),
                                                            Data.GetInt32(5)));

                    }
                    return Student.listStudent;
                }
                conn.Close();
                return Student.listStudent;
            }
            Console.ReadLine();

        }
    }
            

   }

