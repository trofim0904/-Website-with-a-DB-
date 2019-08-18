using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRPZ_VOLSWAGEN.Models.Data;

namespace TRPZ_VOLSWAGEN.Models.User
{
    public class UserVM
    {
        public UserVM()
        {

        }
        public UserVM(UserDTO row)
        {
            Id = row.Id;
            Login = row.Login;
            Password = row.Password;
            
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Login { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

    }
}