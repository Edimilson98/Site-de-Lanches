using TopLanches.Models;

namespace TopLanches.ViewModels
{
  public class LancheListViewModel
  {
    public IEnumerable<Lanche> Lanches { get; set; }
    public string CategoriaAtual { get; set; }
  }
}
