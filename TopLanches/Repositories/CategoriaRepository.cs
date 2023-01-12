using TopLanches.Context;
using TopLanches.Models;
using TopLanches.Repositories.Interfaces;

namespace TopLanches.Repositories
{
  public class CategoriaRepository : ICategoriaRepository
  {
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Categoria> Categorias => _context.Categorias;
  }
}
