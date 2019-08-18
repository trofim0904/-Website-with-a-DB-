using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRPZ_VOLSWAGEN.Models.Data;

namespace TRPZ_VOLSWAGEN.Models.ViewModels.Pages
{
    public class PageVM
    {
        public PageVM()
        {

        }
        public PageVM(PagesDTO row)
        {
            Id = row.Id;
            Name = row.Name;
            Characteristic = row.Characteristic;
            Sorting = row.Sorting;
            Small_Characteristic = row.Small_Characteristic;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string Characteristic { get; set; }

        public int Sorting { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string Small_Characteristic { get;set;}
    }
}