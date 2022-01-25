using Marcos_Sport_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcos_Sport_Store.Controllers
{
    public class ShirtsController : Controller
    {
        static string connectionString = "Data Source=LENOVO-MARCOS;Initial Catalog=SportStoreDb;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportStoreDataContext = new SportStoreDataContext(connectionString);

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetShirts()
        {
            return View(sportStoreDataContext.Clothings.Where(item => item.Type == "Shirts"));
        }
        public ActionResult GetShirtsTable()
        {
            return View(sportStoreDataContext.Clothings.Where(item => item.Type == "Shirts"));
        }
        public ActionResult GetLongShirts()
        {
            return View(sportStoreDataContext.Clothings.Where(item => item.Type == "Shirts" && item.IsShort == false));
        }
        public ActionResult GetShortShirts()
        {
            return View(sportStoreDataContext.Clothings.Where(item => item.Type == "Shirts" && item.IsShort == true));
        }
        public ActionResult GetDryfitShirts()
        {
            return View(sportStoreDataContext.Clothings.Where(item => item.Type == "Shirts" && item.IsDryfit == true));
        }
        public ActionResult GetShirtsByPrice()
        {
            return View(sportStoreDataContext.Clothings.Where(item => item.Type == "Shirts").OrderBy((item) => item.Price));
        }


    }
}