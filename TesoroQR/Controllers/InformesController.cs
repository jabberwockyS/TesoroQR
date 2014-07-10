using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesoroQR.Models.Tesoro;

namespace TesoroQR.Controllers
{
    [Authorize(Roles="Admin")]
    public class InformesController : Controller
    {
        TesoroRepository repo = new TesoroRepository();
        //
        // GET: /Informes/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarPartidas()
        {
            return View(repo.Partidas());
        }

        public ActionResult ListarJugadores(int partidaID)
        {
            Session["partidaID"] = partidaID;
            return View(repo.UsuariosPorPartida(partidaID));
        }


        public ActionResult ListarAvancePorJugador(int jugadorID)
        { 
            int partidaID = Convert.ToInt32( Session["partidaID"]);



            return View(repo.ListarAvancePorJugador(jugadorID, partidaID));
        }

	}
}