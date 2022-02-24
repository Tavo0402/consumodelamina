using ConsumoDeLamina.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoDeLamina.API.Repositories.IRepository
{
    public interface IConsumoDeLaminaRepository
    {
        Task<List<ConsumoDeLaminDTO>> Get();
        Task<ConsumoDeLaminDTO> GetById(int id);
        Task<ConsumoDeLaminDTO> CreateUpdate(ConsumoDeLaminDTO consumoDeLaminDTO);
        Task<bool> Delete(int id);
    }
}
