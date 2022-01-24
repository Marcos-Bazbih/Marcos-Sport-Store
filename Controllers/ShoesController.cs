using Marcos_Sport_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcos_Sport_Store.Controllers
{
    public class ShoesController : Controller
    {
        static string connectionString = "Data Source=LENOVO-MARCOS;Initial Catalog=SportStoreDb;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportStoreDataContext = new SportStoreDataContext(connectionString);

        // GET: Shoes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetShoes()
        {
            return View(sportStoreDataContext.Shoes);
        }
        public ActionResult GetShoesTable()
        {
            return View(sportStoreDataContext.Shoes);
        }

        public ActionResult GetShoesInSale()
        {
            return View(sportStoreDataContext.Shoes.Where(shoe => shoe.InSale == true));
        }
    }
}