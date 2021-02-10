using System.ComponentModel.DataAnnotations.Schema;


namespace WebTechTest.Models.Test3
{
    [Table("Evaluation", Schema = "Test-3")]
    public class Evaluation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        
    }
}
