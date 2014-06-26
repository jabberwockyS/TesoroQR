using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesoroQR.Models.Tesoro
{
    public class Juego
    {
        public int JuegoID { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime horaFin { get; set; }

        public Usuario Juegador { get; set; }
        public Circuito Circuito { get; set; }

    }
}