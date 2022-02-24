using AutoMapper;
using ConsumoDeLamina.API.Repositories.IRepository;
using ConsumoDeLamina.Data;
using ConsumoDeLamina.Entities.DTOs;
using ConsumoDeLamina.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoDeLamina.API.Repositories
{
    public class ConsumoDeLaminaRepository : IConsumoDeLaminaRepository
    {
        private readonly ApplicationDataContext _context;
        private IMapper _mapper;
        public ConsumoDeLaminaRepository(ApplicationDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ConsumoDeLaminDTO> CreateUpdate(ConsumoDeLaminDTO consumoDeLaminDTO)
        {
            ConsumoDeLamin cl = _mapper.Map<ConsumoDeLaminDTO, ConsumoDeLamin>(consumoDeLaminDTO);

            if (cl.Id > 0)
            {
                _context.ConsumoDeLamina.Update(cl);
            }
            else
            {
                await _context.ConsumoDeLamina.AddAsync(cl);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<ConsumoDeLamin, ConsumoDeLaminDTO>(cl);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                ConsumoDeLamin cl = await _context.ConsumoDeLamina.FindAsync(id);
                if (cl == null)
                {
                    return false;
                }
                _context.ConsumoDeLamina.Remove(cl);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ConsumoDeLaminDTO>> Get()
        {
            List<ConsumoDeLamin> cl = await _context.ConsumoDeLamina
                                                    .Include(cl => cl.ConsumoDeLaminaDetalles)
                                                    .ToListAsync();

            return _mapper.Map<List<ConsumoDeLaminDTO>>(cl);
        }

        public async Task<ConsumoDeLaminDTO> GetById(int id)
        {
            ConsumoDeLamin cl = await _context.ConsumoDeLamina.FindAsync(id);
            return _mapper.Map<ConsumoDeLaminDTO>(cl);
        }
    }
}
