using Microsoft.EntityFrameworkCore;

namespace Clinica.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options): base(options)
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}
