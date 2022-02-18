using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Data.UnitOfWork;

namespace Kutuphane.Controllers
{
    public class UyeController : Controller
    {
        UnitOfWork unitOfWork;
        public UyeController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}