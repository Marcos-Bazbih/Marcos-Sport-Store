using Marcos_Sport_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcos_Sport_Store.Controllers
{
    public class EquipmentController : Controller
    {
        static string connectionString = "Data Source=LENOVO-MARCOS;Initial Catalog=SportStoreDb;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportStoreDataContext = new SportStoreDataContext(connectionString);

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetEquipment()
        {
            return View(sportStoreDataContext.Equipments);
        }
        public ActionResult GetEquipmentTable()
        {
            return View(sportStoreDataContext.Equipments);
        }


    }
}