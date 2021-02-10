using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTechTest.Models.Test3
{
    [Table("Course", Schema = "Test-3")]
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public List<Evaluation> Evaluations {get;set;}        
    }
}
