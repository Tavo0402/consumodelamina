using ConsumoDeLamina.Entities.DTOs;
using ConsumoDeLamina.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoDeLamina.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }
        public DbSet<ConsumoDeLamin> ConsumoDeLamina { get; set; }
        public DbSet<ConsumoDeLaminaDetalles> ConsumoDeLaminaDetalles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
