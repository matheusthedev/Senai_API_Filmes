using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_filmes_senai.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly Filmes_Context _context;
        public FilmeRepository(Filmes_Context context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Filme filme)
        {
            try
            {
                Filme filmeBuscado = _context.Filmes.Find(id)!;

                if (filmeBuscado != null)
                {
                    filmeBuscado.Titulo = filme.Titulo;
                    filmeBuscado.IdGenero = filme.IdGenero;
                }

                _context.SaveChanges();

            }

            catch (Exception)
            {

                throw;
            }
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            {
                Filme filmesBuscado = _context.Filmes.Find(id)!;

                return filmesBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Filme novoFilme)
        {
            try
            {
                _context.Filmes.Add(novoFilme);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filmes.Find(id);

                if (filmeBuscado != null)
                {
                    _context.Remove(filmeBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filmes.Include(g => g.Genero).ToList();

                return listaDeFilmes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> ListarPorGenero(Guid idGenero)
        {
            return _context.Filmes.Where(f => f.IdGenero == idGenero).ToList();ss
        }
    }
}
