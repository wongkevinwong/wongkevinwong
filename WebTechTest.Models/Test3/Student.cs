using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTechTest.Models.Test3
{
    [Table("Student", Schema = "Test-3")]
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public List<Course> Courses{ get; set; }
    }

    


}
