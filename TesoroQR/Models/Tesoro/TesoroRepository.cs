using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesoroQR.Models.Tesoro;

namespace TesoroQR.Models.Tesoro
{
    public class TesoroRepository
    {
        JuegoDBContext db = new JuegoDBContext();



        public List<Partida> Partidas()
        {
            return db.Partidas.ToList();
        }

        public List<Usuario> UsuariosPorPartida(int partidaID)
        {
            List<Usuario> usuarios = db.Usuarios.ToList();
            List<Usuario> usuariosSalida = new List<Usuario>();

            List<Juego> juegosPartida = db.Juegos.Where(x => x.Partida.PartidaID == partidaID).ToList();

           

            foreach(Usuario usuario in usuarios)
            {
                List<Juego> juegos =db.Juegos.Where(x => x.Jugador.UsuarioID == usuario.UsuarioID).ToList();

                foreach(Juego juegoj in juegos)
                {
                    foreach(Juego juegop in juegosPartida)
                    {
                        if(juegop.JuegoID == juegoj.JuegoID)
                        {
                            usuariosSalida.Add(usuario);
                        }
                    }
                }

                
                
            }





            

            return usuariosSalida;
        }


        public List<Avance> ListarAvancePorJugador(int jugadorID, int partidaID)
        {
            List<Avance> avances = new List<Avance>();

            avances = db.Avances.Where(x => x.Juego.Jugador.UsuarioID == jugadorID && x.Juego.Partida.PartidaID == partidaID).ToList();

            
            
            
            
            
            return avances;
        }


    }
}