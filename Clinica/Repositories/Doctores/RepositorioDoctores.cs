using Clinica.Components.Pages.Pacientes;
using Clinica.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Repositories.Doctores
{
    public class RepositorioDoctores : IRepositorioDoctores
    {
        private readonly ContextDB _context;

        public RepositorioDoctores(ContextDB context)
        {
            _context = context;
        }

        public async Task Add(Doctor doctor)
        {
            await _context.Doctores.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CanDelete(int id)
        {
            Doctor doctor = await _context.Doctores.Include(d => d.Consultas).SingleAsync(d => d.Id == id);
            return doctor.Consultas.Count() == 0;
        }

        public async Task Delete(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Doctores WHERE Id = {0}", id);
        }

        public async Task<Doctor> Get(int id)
        {
            return await _context.Doctores.FindAsync(id);

        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _context.Doctores.AsNoTracking().ToListAsync();
        }

        public async Task Update(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
