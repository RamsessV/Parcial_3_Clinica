using Clinica.Data;

namespace Clinica.Repositories.Consultas
{
    public interface IRepositorioConsultas
    {
        Task<List<Consulta>> GetAll();
        Task<Consulta> Get(int id);
        Task Add(Consulta consulta);
        Task Delete(int id);
        Task Update(Consulta consulta);
    }
}
