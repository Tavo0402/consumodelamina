using ConsumoDeLamina.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoDeLamina.Entities.DTOs
{
    public class ConsumoDeLaminDTO
    {
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Notas { get; set; } = string.Empty;

        public IEnumerable<ConsumoDeLaminaDetalles> ConsumoDeLaminaDetalles { get; set; }
    }
}
