using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoDeLamina.Entities.DTOs
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
