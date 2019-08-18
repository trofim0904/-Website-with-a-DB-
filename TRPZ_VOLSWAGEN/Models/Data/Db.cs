using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TRPZ_VOLSWAGEN.Models.Data
{
    public class StoreDb : DbContext 
    {
        public StoreDb() : base("StoreDb")
        {

        }


        public DbSet<PagesDTO> Pages { get; set; }
        
        public DbSet<CategoryDTO> Categories { get; set; }

        public DbSet<UserDTO> User { get; set; }

    }
}