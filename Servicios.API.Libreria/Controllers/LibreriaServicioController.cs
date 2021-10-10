using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.API.Libreria.Core.Entities;
using Servicios.API.Libreria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.API.Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaServicioController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMongoRepository<AutorEntity> _autorGerenicRepository;

        public LibreriaServicioController(IAutorRepository autorRepository, IMongoRepository<AutorEntity> autorGenericRepository)
        {
            _autorRepository = autorRepository;
            _autorGerenicRepository = autorGenericRepository;
        }

        [HttpGet("autores")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await _autorRepository.GetAutores();
            return Ok(autores);
        }

        [HttpGet("autorGenerico")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutorGenerico()
        {
            var autores = await _autorGerenicRepository.GetAll();
            return Ok(autores);
        }
    }
}
