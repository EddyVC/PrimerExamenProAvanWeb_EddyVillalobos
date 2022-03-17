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
    public class AutoresController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public AutoresController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Autores>>> GetAutores()
        {
            //return new BE.BS.Autores(_context).GetAll().ToList();
            var res = new BE.BS.Autores(_context).GetAll();
            List<models.Autores> mapaAux = _mapper.Map<IEnumerable<data.Autores>, IEnumerable<models.Autores>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Autores>> GetAutores(int id)
        {
            var autores = new BE.BS.Autores(_context).GetOneById(id);

            if (autores == null)
            {
                return NotFound();
            }
            models.Autores mapaAux = _mapper.Map<data.Autores, models.Autores>(autores);
            return mapaAux;
        }

        // PUT: api/Autores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutores(int id, models.Autores autores)
        {
            if (id != autores.Id)
            {
                return BadRequest();
            }

            try
            {
                data.Autores mapaAux = _mapper.Map<models.Autores, data.Autores>(autores);
                new BE.BS.Autores(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!AutoresExists(id))
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

        // POST: api/Autores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Autores>> PostAutores(models.Autores autores)
        {
            try
            {
                var mapAux = _mapper.Map<models.Autores, data.Autores>(autores);
                new BE.BS.Autores(_context).Insert(mapAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetAutores", new { id = autores.Id }, autores);
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Autores>> DeleteAutores(int id)
        {
            var autores = new BE.BS.Autores(_context).GetOneById(id);
            if (autores == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Autores(_context).Delete(autores);
            }
            catch (Exception)
            {
                BadRequest();
            }
            var mapAux = _mapper.Map<data.Autores, models.Autores>(autores);
            return mapAux;
        }

        private bool AutoresExists(int id)
        {
            return (new BE.BS.Autores(_context).GetOneById(id) != null);
        }
    }
}
