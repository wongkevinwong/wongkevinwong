using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebTechTest.Models.Test1
{
    [Table("Person", Schema = "Test-1")]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<PersonAdGroup> PersonAdGroups { get; set; }
    }
}
