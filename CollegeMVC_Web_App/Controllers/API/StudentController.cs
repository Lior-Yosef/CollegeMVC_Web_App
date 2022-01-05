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
            List<Student> listStudent = new List<Student>();
            try{ 
            using (SqlConnection conn = new SqlConnection(connctionString))
            {
                conn.Open();
                string query = @"SELECT * FROM Student";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader DataFromDB = cmd.ExecuteReader();

                if (DataFromDB.HasRows)
                {
                    while (DataFromDB.Read())
                    {
                        listStudent.Add(new Student(DataFromDB.GetString(1),DataFromDB.GetString(2),DataFromDB.GetDateTime(3),DataFromDB.GetString(4),DataFromDB.GetInt32(5) ));
                    }

                    conn.Close();
                    return Ok(new { listStudent });

                }
                else
                {
                    string somomo = "stam string";
                    conn.Close();
                    return Ok(new { somomo });
                }
            }

            }
            catch (SqlException ex) { return BadRequest(ex.Message); }

            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        // GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connctionString))
                {
                    conn.Open();
                    string query = $@"SELECT * FROM Student WHERE Id={id}";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader DataFromDB = cmd.ExecuteReader();
                    if (DataFromDB.HasRows)
                    {
                        while (DataFromDB.Read())
                        {
                            Student ObjectStudent = new Student(DataFromDB.GetString(1), DataFromDB.GetString(2), DataFromDB.GetDateTime(3), DataFromDB.GetString(4), DataFromDB.GetInt32(5));
                            conn.Close();
                            return Ok(ObjectStudent);
                        }
                    }

                    else
                    {
                        string somomo = "stam string";
                        conn.Close();
                        return Ok(new { somomo });
                    }
                }


            }
            catch (SqlException ex) { return BadRequest(ex.Message); }

            catch (Exception ex) { return BadRequest(ex.Message); }
            return Ok();
        }

        // POST: api/Student
        public IHttpActionResult Post([FromBody] Student value)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connctionString))
                {
                    conn.Open();
                    string query = $@"INSERT INTO Student (FullName,LastName,BornYear,Email,YearStudent)
                                    VALUES( '{value.FirstName}' ,'{value.LastName}','{value.BornYear}','{value.Email}',{value.YearStudent})";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int row = cmd.ExecuteNonQuery();
                    return Get();

                }
            }
            catch (SqlException ex) { return BadRequest(ex.Message); }

            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody] string value)
        {
            //string query = $@"UPDATE Student 
                                    //SET FullName = '{value.FirstName}' , FullName = '{value.FirstName}',LastName = '{value.LastName}',BornYear = '{value.BornYear}',Email = '{value.Email}',YearStudent = '{value.YearStudent}'";
            //SqlCommand cmd = new SqlCommand(query, conn);
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }

    }
   }

