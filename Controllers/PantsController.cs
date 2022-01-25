﻿using Marcos_Sport_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marcos_Sport_Store.Controllers
{
    public class PantsController : Controller
    {
        static string connectionString = "Data Source=LENOVO-MARCOS;Initial Catalog=SportStoreDb;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportStoreDataContext = new SportStoreDataContext(connectionString);
        // GET: Pants
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetPants()
        {
            return View(sportStoreDataContext.Clothings.Where(item => item.Type == "Pants"));
        }
        public ActionResult GetPantsTable()
        {
            return View(sportStoreDataContext.Clothings.Where(item => item.Type == "Pants"));
        }
    }
}