using System.ComponentModel.DataAnnotations.Schema;

namespace WebTechTest.Models.Test1
{
    [Table("PersonAdGroup", Schema = "Test-1")]
    public class PersonAdGroup
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int AdGroupId { get; set; }
        public AdGroup AdGroup { get; set; }
    }
}
