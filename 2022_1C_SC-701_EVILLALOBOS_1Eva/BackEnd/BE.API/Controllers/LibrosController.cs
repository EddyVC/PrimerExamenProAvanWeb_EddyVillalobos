using AutoMapper;
using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;
using models = BE.API.DataModels;

namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public LibrosController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Libros>>> GetLibros()
        {
            var res = await new BE.BS.Libros(_context).GetAllAsync();
            List<models.Libros> mapaAux = _mapper.Map<IEnumerable<data.Libros>, IEnumerable<models.Libros>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Libros>> GetLibros(int id)
        {
            var libros = await new BE.BS.Libros(_context).GetOneByIdAsync(id);

            if (libros == null)
            {
                return NotFound();
            }
            models.Libros mapaAux = _mapper.Map<data.Libros, models.Libros>(libros);

            return mapaAux;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibros(int id, models.Libros libros)
        {
            if (id != libros.Id)
            {
                return BadRequest();
            }

            try
            {
                data.Libros mapaAux = _mapper.Map<models.Libros, data.Libros>(libros);
                new BE.BS.Libros(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!LibrosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Libros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Libros>> PostLibros(models.Libros libros)
        {
            try
            {
                var mapAux = _mapper.Map<models.Libros, data.Libros>(libros);
                new BE.BS.Libros(_context).Insert(mapAux);
            }
            catch (Exception ee)
            {
                BadRequest(ee);
            }

            return CreatedAtAction("GetLibros", new { id = libros.Id }, libros);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Libros>> DeleteLibros(int id)
        {
            var libros = await new BE.BS.Libros(_context).GetOneByIdAsync(id);
            if (libros == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Libros(_context).Delete(libros);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Libros mapaAux = _mapper.Map<data.Libros, models.Libros>(libros);

            return mapaAux;
        }

        private bool LibrosExists(int id)
        {
            return (new BE.BS.Libros(_context).GetOneById(id) != null);
        }
    }
}

