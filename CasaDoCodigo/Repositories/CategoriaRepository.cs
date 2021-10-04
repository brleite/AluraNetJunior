using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Categoria> GetCategorias()
        {
            return dbSet.ToList();
        }

        public async Task<Categoria> SaveCategoria(string nome)
        {
            var categoria = dbSet.Where(c => c.Nome == nome).SingleOrDefault();

            if (categoria == null)
            {
                categoria = dbSet.Add(new Categoria(nome)).Entity;
                await contexto.SaveChangesAsync();
            }

            return categoria;            
        }
    }
}
