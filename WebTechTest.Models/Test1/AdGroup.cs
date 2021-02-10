using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebTechTest.Models.Test1
{
    [Table("AdGroup", Schema = "Test-1")]
    public class AdGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }

        public List<PersonAdGroup> PersonAdGroups { get; set; }
    }
}
