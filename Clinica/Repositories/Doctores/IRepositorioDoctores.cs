using Clinica.Data;

namespace Clinica.Repositories.Doctores
{
    public interface IRepositorioDoctores
    {
        Task<List<Doctor>> GetAll();
        Task<Doctor> Get(int id);
        Task Add(Doctor doctor);
        Task Delete(int id);
        Task Update(Doctor doctor);
        Task<bool> CanDelete(int id);

    }
}
