using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRPZ_VOLSWAGEN.Models.Data;
using TRPZ_VOLSWAGEN.Models.ViewModels.Pages;

namespace TRPZ_VOLSWAGEN.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        [Authorize]
        public ActionResult Buy()
        {
            List<PageVM> pageList;

            using (StoreDb StoreDb = new StoreDb())
            {
                //pageList = StoreDb.Pages.ToArray().OrderBy(x => x.Sorting).Select(x => new PageVM(x)).ToList();
                pageList = StoreDb.Pages.ToArray().OrderBy(x => x.Sorting).Select(x => new PageVM(x)).ToList();
            }
            return View(pageList);
        }
        public ActionResult CarDetails(int id)
        {
            PageVM model;

            using (StoreDb storeDb = new StoreDb())
            {
                PagesDTO pagesDTO = storeDb.Pages.Find(id);
                if (storeDb == null)
                {
                    return Content("This page does not exist");

                }

                model = new PageVM(pagesDTO);
                return View(model);
            }

        }
    }
}