using System.Reflection.Metadata.Ecma335;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        /// <summary>
        /// Endpoint Listar todos os Gêneros Cadastrados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Gêneros Cadastrados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint para Cadastrar um Gênero
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Gênero Cadastrado</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Genero novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar um Gênero pelo seu id
        /// </summary>
        /// <param name="id">Id do Gênero buscado</param>
        /// <returns>Gênero Buscado</returns>

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Genero generoBuscado = _generoRepository.BuscarPorId(id);

                return Ok(generoBuscado);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar Gêneros
        /// </summary>
        /// <param name="id">Id do Gênero Deletado</param>
        /// <returns>Gêneros Deletados</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _generoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Endpoint Para dar update nos Gêneros
        /// </summary>
        /// <param name="id">Id do Gênero Atualizado    </param>
        /// <returns>Gênero Atualizado</returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Genero genero)
        {
            try
            {
                _generoRepository.Atualizar(id, genero);

                return NoContent() ;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
