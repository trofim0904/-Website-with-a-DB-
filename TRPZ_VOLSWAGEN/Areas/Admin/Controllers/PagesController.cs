using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRPZ_VOLSWAGEN.Models.Data;
using TRPZ_VOLSWAGEN.Models.ViewModels.Pages;

namespace TRPZ_VOLSWAGEN.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        // GET: Admin/Pages
        public ActionResult Index()
        {
            List<PageVM> pageList;

            using (StoreDb StoreDb = new StoreDb())
            {
                //pageList = StoreDb.Pages.ToArray().OrderBy(x => x.Sorting).Select(x => new PageVM(x)).ToList();
                pageList = StoreDb.Pages.ToArray().OrderBy(x => x.Sorting).Select(x => new PageVM(x)).ToList();
            }
            return View(pageList);
        }

        [HttpGet]
        public ActionResult AddPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPage(PageVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (StoreDb storeDb = new StoreDb())
            {
                string charac; //характеристика або опис (атрибут бд)

                PagesDTO pagesDTO = new PagesDTO();
                pagesDTO.Name = model.Name.ToUpper();

                if (string.IsNullOrWhiteSpace(model.Small_Characteristic))
                {
                    charac = model.Name.Replace(" ", "-").ToLower();
                }
                else
                {
                    charac = model.Small_Characteristic.Replace(" ", "-").ToLower();
                }

                if (storeDb.Pages.Any(x => x.Name == model.Name))
                {
                    ModelState.AddModelError("", "This name already exist!!!");
                    return View(model);
                }
                else
                if (storeDb.Pages.Any(x => x.Small_Characteristic == model.Small_Characteristic))
                {
                    ModelState.AddModelError("", "This small characteristic already exist!!!");
                    return View(model);
                }

                pagesDTO.Small_Characteristic = charac;
                pagesDTO.Characteristic = model.Characteristic;
                pagesDTO.Name = model.Name;
                pagesDTO.Sorting = 100;

                storeDb.Pages.Add(pagesDTO);
                storeDb.SaveChanges();
            }

            TempData["SM"] = "You have added a new page";
            return RedirectToAction("Index");

       
        }
        [HttpGet]
        public ActionResult EditPage(int id)
        {
            PageVM model;

            using (StoreDb storeDb =new StoreDb())
            {
                PagesDTO pagesDTO = storeDb.Pages.Find(id);
                if (pagesDTO == null)
                {
                    return Content("This page does not exist!!!");

                }
                model = new PageVM(pagesDTO);

                return View(model);
            }
        }
        [HttpPost]
        public ActionResult EditPage(PageVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (StoreDb storeDb = new StoreDb())
            {
                int id = model.Id;

                string charac;
                PagesDTO pagesDTO = storeDb.Pages.Find(id);
                pagesDTO.Name = model.Name;
                pagesDTO.Characteristic = model.Characteristic;

                if (string.IsNullOrWhiteSpace(model.Small_Characteristic))
                {
                    charac = model.Name.Replace(" ", "-").ToLower();

                }
                else
                {
                    charac = model.Small_Characteristic.Replace(" ", "-").ToLower();

                }

                if (storeDb.Pages.Where(x=> x.Id!=id).Any(x=>x.Name == model.Name))
                {
                    ModelState.AddModelError("", "That Name already exist.");
                    return View(model);
                    
                }
                else
                    if(storeDb.Pages.Where(x => x.Id != id).Any(x => x.Small_Characteristic == charac))
                    {
                        ModelState.AddModelError("", "That Small Characreristic already exist.");
                        return View(model);
                    }
                pagesDTO.Small_Characteristic = charac;
                pagesDTO.Name = model.Name;
                pagesDTO.Characteristic = model.Characteristic;

                storeDb.SaveChanges();


                
            }
            TempData["SM"] = "You have edited the page.";
            return RedirectToAction("EditPage");
        }

        public ActionResult PageDetails(int id)
        {
            PageVM model;

            using (StoreDb storeDb= new StoreDb())
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
        public ActionResult DeletePage(int id)
        {
            using (StoreDb storeDb =new StoreDb())
            {
                PagesDTO pagesDTO = storeDb.Pages.Find(id);
                storeDb.Pages.Remove(pagesDTO);
                storeDb.SaveChanges();

            }

            TempData["SM"] = "You delete a page";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public void ReorderPages(int [] Id)
        {
            using (StoreDb storeDb=new StoreDb())
            {
                int count = 1;
                PagesDTO pagesDTO;
                foreach(var pageId in Id)
                {
                    pagesDTO = storeDb.Pages.Find(pageId);
                    pagesDTO.Sorting = count;
                    storeDb.SaveChanges();
                    count++;

                }
            }
        }
    }
}