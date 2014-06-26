using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesoroQR.Controllers
{
    [Authorize]
    public class PistasController : Controller
    {
        //
        // GET: /Pistas/
        public ActionResult Index()
        {
            return View();
        }
	}
}