using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesoroQR.Models.Tesoro
{
    public class DetalleCircuito
    {
       
        public int DetalleCircuitoID { get; set; }

        public Circuito Circuito { get; set; }

        public Pista Pistas { get; set; }

        public int Orden { get; set; }




    }
}