using Clinica.Data;

namespace Clinica.Repositories.Doctores
{
    public interface IRepositorioDoctores
    {
        Task<List<Doctor>> GetAll();
        Task<Doctor> Get(int id);
        Task<Doctor> GetByName(string name);
        Task Add(Doctor doctor);
        Task Delete(int id);
        Task Update(Doctor doctor);

    }
}
