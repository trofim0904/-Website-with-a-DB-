using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRPZ_VOLSWAGEN.Models.Data;
using TRPZ_VOLSWAGEN.Models.ViewModels.Shop;

namespace TRPZ_VOLSWAGEN.Areas.Admin.Controllers
{
    public class ShopController : Controller
    {
        // GET: Admin/Shop
        public ActionResult Categories()
        {
            List<CategoryVM> categoryVMList;
            using (StoreDb storeDb =new StoreDb())
            {
                categoryVMList = storeDb.Categories.ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x)).ToList();
            }
                return View(categoryVMList);
        }
    }
}