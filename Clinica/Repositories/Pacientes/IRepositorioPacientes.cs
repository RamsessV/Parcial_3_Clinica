using Clinica.Data;

namespace Clinica.Repositories.Pacientes
{
    public interface IRepositorioPacientes
    {
        Task<List<Paciente>> GetAll();
        Task<Paciente> Get(int id);
        Task Add(Paciente paciente);
        Task Delete(int id);
        Task Update(Paciente paciente);
        Task<bool> CanDelete(int id);
    }
}
