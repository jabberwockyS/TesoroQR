using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesoroQR.Models.Tesoro;

namespace TesoroQR.Controllers
{
    public class CaminoController : Controller
    {
        JuegoDBContext db = new JuegoDBContext();

        

        //
        // GET: /Camino/
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult SelecCircuito()
        {
            List<Circuito> circuitos = db.Circuitos.ToList();
            return View(circuitos);


        }

        [HttpPost]
        public ActionResult SelecCircuito(Circuito circuito)
        {
            return View();
        }
	}
}