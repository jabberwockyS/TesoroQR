﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesoroQR.Models.Tesoro
{
    public class Circuito
    {
        public int CircuitoID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Pista> Pistas { get; set; }

    }
}