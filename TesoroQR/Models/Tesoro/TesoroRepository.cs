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

           

            foreach(Usuario usuario in usuarios)
            {
                List<Juego> juegos =db.Juegos.Where(x => x.Jugador.UsuarioID == usuario.UsuarioID).ToList();

                usuario.Juegos = juegos;
                
            }





            

            return usuarios;
        }


    }
}