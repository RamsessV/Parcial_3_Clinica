using Clinica.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Repositories.Consultas
{
    public class RepositorioConsultas : IRepositorioConsultas
    {
        private readonly ContextDB _context;

        public RepositorioConsultas(ContextDB context)
        {
            _context = context;
        }

        public async Task Add(Consulta consulta)
        {
            await _context.Consultas.AddAsync(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Consultas WHERE Id = {0}", id);
        }

        public async Task<Consulta> Get(int id)
        {
            return await _context.Consultas.FindAsync(id);
        }

        public async Task<List<Consulta>> GetAll()
        {
            return await _context.Consultas.Include(c => c.Doctor).Include(c => c.Paciente).AsNoTracking().ToListAsync();
        }

        public async Task Update(Consulta consulta)
        {
            _context.Entry(consulta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
