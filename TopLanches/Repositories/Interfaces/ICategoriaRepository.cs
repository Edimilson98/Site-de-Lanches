using TopLanches.Models;

namespace TopLanches.Repositories.Interfaces
{
  public interface ICategoriaRepository
  {
    IEnumerable<Categoria> Categorias { get;  }
  }
}
