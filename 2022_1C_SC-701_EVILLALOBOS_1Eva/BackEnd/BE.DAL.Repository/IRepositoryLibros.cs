using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL.Repository
{
    public interface IRepositoryLibros : IRepository<data.Libros>
    {
        Task<IEnumerable<data.Libros>> GetAllAsync();
        Task<data.Libros> GetAllByIdAsync(int id);
    }
}
