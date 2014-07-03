using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesoroQR.Models.Tesoro;

namespace TesoroQR.Controllers
{
    [Authorize]
    public class PistasController : Controller
    {

        JuegoDBContext db = new JuegoDBContext();
        //
        // GET: /Pistas/
        public ActionResult Index( int id)
        {
            return View(db.Pistas.Where(x=> x.Circuito.CircuitoID == id ).ToList());
        }


        public ActionResult VerPista(int Id)
        {

            if (Id == 5)
            {
               return RedirectToAction("Gano");
            }
            else
            {
                Pista pista = db.Pistas.Single(x => x.orden == Id);
                return View(pista);
            }



           // return View();
        }

        public ActionResult Gano()
        {
            return View();
        }
	}
}