using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            Session["CircuitoID"] = id;
            return View(db.Pistas.Where(x=> x.Circuito.CircuitoID == id ).ToList());
        }


        public ActionResult VerPista(int Id)
        {
            //aca controla que sea un codigo de inicio de camino
            if(Id == 1 || Id == 6 || Id == 11 || Id == 16)
            {
                //si el usuario no existe
                String nombreUsuario = User.Identity.Name;
                Partida partida = db.Partidas.Single(x => x.Fecha.CompareTo(DateTime.Today) == 0);
                Usuario usuario;
               

                //guardo el usuario si es que ya no existe
                if (!db.Usuarios.Any(x => x.Nombre == nombreUsuario))
                {
                     usuario = new Usuario() { Nombre = nombreUsuario, TipoUsuario = "jugador" };
                    db.Usuarios.Add(usuario);
                    //guardo el usuario
                    db.SaveChanges();
                }
                else
                {
                    usuario = db.Usuarios.Single(x => x.Nombre == nombreUsuario);
                }

                Juego juego = new Juego() { HoraInicio = DateTime.Now,horaFin = DateTime.Now, Jugador = usuario, Partida = partida };

                
                //si la partida es la primera y no es el mismo dia(si es otro dia deberia solo registrar la partida)
                if(!db.Juegos.Any(x=> x.Jugador.Nombre == nombreUsuario && x.Partida.Fecha.CompareTo(DateTime.Today) == 0) )
                {
                    
                    //agrego un el juego si es que no existe
                    
                    db.Juegos.Add(juego);

                    //guardo la partida
                    db.SaveChanges();
                }

               


                List<Circuito> circuitosList = db.Circuitos.Where(x=> x.Partida.PartidaID == partida.PartidaID).ToList();
                Circuito circuito;

                
                if(Id==1)
                    circuito = circuitosList[0];
                else if(Id == 6)
                    circuito = circuitosList[1];
                else if(Id == 11)
                    circuito = circuitosList[2];
                else
                    circuito = circuitosList[3];

                Juego juegoAvance = db.Juegos.Single(x=> x.Jugador.Nombre == nombreUsuario && x.Partida.Fecha.CompareTo(DateTime.Today)== 0);
                db.Avances.Add(new Avance() { UltimaPista = 1, Circuito = circuito, Juego = juegoAvance  });
                //guardo el avance
                db.SaveChanges();
                
             
            }

            //aca controla que sea un codigo de final de camino
            if (Id == 5 || Id == 10 || Id == 15 || Id == 20)
            {
               return RedirectToAction("Gano");
            }

            //ahora controlemos cualquiera de las otras pista que no son finales!

            Partida part = db.Partidas.Single(x => x.Fecha.CompareTo(DateTime.Today) == 0);
            List<Circuito> circList = db.Circuitos.Where(x => x.Partida.PartidaID == part.PartidaID).ToList();
            Circuito circ;
            //arreglo el Id para que se corresponda con el orden teniendo en cuenta el circuito
            if (Id > 15)
            {
                Id = Id - 5;
                circ = circList[3];
            }
            else if (Id > 10)
            {
                Id = Id - 10;
                circ = circList[2];
            }
            else if (Id > 5)
            {
                Id = Id - 5;
                circ = circList[1];
            }
            else
                circ = circList[0];

            
            Pista pista = db.Pistas.Single(x=> x.Circuito.CircuitoID == circ.CircuitoID && x.orden == Id);


            return View(pista);


           



           // return View();
        }

        public ActionResult Gano()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pista pista = db.Pistas.Find(id);
            if (pista == null)
            {
                return HttpNotFound();
            }
            return View(pista);
        }

        // GET: /Esta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Esta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PistaID,Nombre,Descripcion,orden")] Pista pista)
        {
            if (ModelState.IsValid)
            {
                int circuitoID = Convert.ToInt32(Session["CircuitoID"]);
                pista.Circuito = db.Circuitos.Single(x => x.CircuitoID == circuitoID);
                db.Pistas.Add(pista);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = circuitoID });
            }

            return View(pista);
        }

        // GET: /Esta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pista pista = db.Pistas.Find(id);
            if (pista == null)
            {
                return HttpNotFound();
            }
            return View(pista);
        }

        // POST: /Esta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PistaID,Nombre,Descripcion,orden")] Pista pista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pista).State = EntityState.Modified;
                db.SaveChanges();
                int circuitoID = Convert.ToInt32(Session["CircuitoID"]);
                return RedirectToAction("Index", new { id = circuitoID });
            }
            return View(pista);
        }

        // GET: /Esta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pista pista = db.Pistas.Find(id);
            if (pista == null)
            {
                return HttpNotFound();
            }
            return View(pista);
        }

        // POST: /Esta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pista pista = db.Pistas.Find(id);
            db.Pistas.Remove(pista);
            db.SaveChanges();
            int circuitoID = Convert.ToInt32(Session["CircuitoID"]);
            return RedirectToAction("Index", new { id = circuitoID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

	
