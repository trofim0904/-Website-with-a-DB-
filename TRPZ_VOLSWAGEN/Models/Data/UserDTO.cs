using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TRPZ_VOLSWAGEN.Models.Data
{
    [Table("tblUser")]
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
   
    }
}