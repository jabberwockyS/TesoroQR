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

            return View(repo.UsuariosPorPartida(partidaID));
        }
	}
}