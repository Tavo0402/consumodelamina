using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoDeLamina.Entities.Models
{
    public class ConsumoDeLaminaDetalles
    {
        //Lamina Galvanizada
        public int Id { get; set; }
        public double Cantidad10 { get; set; }
        public double Peso10 { get; set; }
        public double Cantidad14 { get; set; }
        public double Peso14 { get; set; }
        public double Cantidad16 { get; set; }
        public double Peso16 { get; set; }
        public double Cantidad18 { get; set; }
        public double Peso18 { get; set; }
        public double Cantidad20 { get; set; }
        public double Peso20 { get; set; }
        public double Cantidad22 { get; set; }
        public double Peso22 { get; set; }
        public double Cantidad24 { get; set; }
        public double Peso24 { get; set; }
        public double Cantidad26 { get; set; }
        public double Peso26 { get; set; }

        //Standig Rig
        public double PesoSR26 { get; set; }
        public double PesoSR28 { get; set; }

        //Liso
        public double PesoLiso18 { get; set; }
        public double PesoLiso20 { get; set; }
        public double PesoLiso22 { get; set; }
        public double PesoLiso24 { get; set; }
        public double PesoLiso26 { get; set; }
        public double PesoLiso28 { get; set; }

        public ConsumoDeLamin consumoDeLamina { get; set; }
    }
}
