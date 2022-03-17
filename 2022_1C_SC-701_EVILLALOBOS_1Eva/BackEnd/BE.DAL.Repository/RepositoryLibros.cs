using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL.Repository
{
    public class RepositoryLibros : Repository<data.Libros>, IRepositoryLibros
    {
        public RepositoryLibros(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<Libros>> GetAllAsync()
        {
            return await _db.Libros.Include(n => n.Autor).ToListAsync();
        }

        public async Task<Libros> GetAllByIdAsync(int id)
        {
            return await _db.Libros.Include(n => n.Autor).SingleOrDefaultAsync(n => n.Id == id);
        }

        private NDbContext _db
        {
            get
            {
                return dbContext as NDbContext;
            }
        }
    }
}
