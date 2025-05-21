using Clinica.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Repositories.Pacientes
{
    public class RepositorioPacientes : IRepositorioPacientes
    {
        private readonly ContextDB _context;

        public RepositorioPacientes(ContextDB context)
        {
            _context = context;
        }
        public async Task Add(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CanDelete(int id)
        {
            Paciente p = await _context.Pacientes.Include(p => p.Consultas).SingleAsync(p => p.Id == id);
            return p.Consultas.Count() == 0;
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Pacientes WHERE Id = {0}", id);
        }

        public async Task<Paciente> Get(int id)
        {
            return await _context.Pacientes.Include(p => p.Consultas).SingleAsync(p => p.Id == id);
        }

        public async Task<List<Paciente>> GetAll()
        {
            return await _context.Pacientes.AsNoTracking().ToListAsync();
        }

        public async Task Update(Paciente paciente)
        {
            _context.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
