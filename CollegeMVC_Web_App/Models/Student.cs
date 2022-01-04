using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeMVC_Web_App.Models
{
    public class Student
    {

        public Student(string firstName, string lastName, DateTime bornYear, string email, int yearStudent)
        {
            FirstName = firstName;
            LastName = lastName;
            BornYear = bornYear;
            Email = email;
            YearStudent = yearStudent;
        }

        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BornYear { get; set; }
        string Email { get; set; }
        int YearStudent { get; set; }

        public static List<Student> listStudent = new List<Student>();

    }
}