using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoDeLamina.Entities.Models
{
    public class ConsumoDeLamin
    {
        public int Id { get; set; }
        [Required]
        public int IdProyecto { get; set; }
        [Required]
        public DateTime FechaInicial { get; set; }
        [Required]
        public DateTime FechaFinal { get; set; }
        public string Notas { get; set; } = string.Empty;

        public IEnumerable<ConsumoDeLaminaDetalles> ConsumoDeLaminaDetalles { get; set; }
    }
}
