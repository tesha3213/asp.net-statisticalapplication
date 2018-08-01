using LapBK_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace LapBK_MVC.Controllers
{
    public class ThonController : Controller
    {
        // GET: Thon
        public ActionResult Index()
        {
            
            return View();
        }
    }
} 