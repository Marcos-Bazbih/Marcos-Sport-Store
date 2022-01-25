using Marcos_Sport_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcos_Sport_Store.Controllers
{
    public class ClothingController : Controller
    {
        static string connectionString = "Data Source=LENOVO-MARCOS;Initial Catalog=SportStoreDb;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportStoreDataContext = new SportStoreDataContext(connectionString);

        // GET: Clothing
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetShirts()
        {
            return View(sportStoreDataContext.Clothings.Where(item => item.Type == "Shirts"));
        }

        public ActionResult GetPants()
        {
            return View(sportStoreDataContext.Clothings.Where(item => item.Type == "Pants"));
        }

    }
}