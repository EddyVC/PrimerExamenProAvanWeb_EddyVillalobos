using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objetos;
using BE.DAL.EF;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.Repository;

namespace BE.DAL
{
    public class Libros : ICRUD<data.Libros>
    {
        private RepositoryLibros repo;
        public Libros(NDbContext dbContext)
        {
            repo = new RepositoryLibros(dbContext);
        }
        public void Delete(data.Libros t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Libros> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Libros>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Libros GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Libros> GetOneByIdAsync(int id)
        {
            return repo.GetAllByIdAsync(id);
        }

        public void Insert(data.Libros t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Libros t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
