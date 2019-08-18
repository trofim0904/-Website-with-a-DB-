using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TRPZ_VOLSWAGEN.Models.Data
{
    [Table("tblPages")]
    public class PagesDTO
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Characteristic { get; set; }
        public int Sorting { get; set; }
        public string Small_Characteristic { get; set; }
    }
}