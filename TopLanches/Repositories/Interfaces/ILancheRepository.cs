using TopLanches.Models;

namespace TopLanches.Repositories.Interfaces
{
  public interface ILancheRepository
  {
    IEnumerable<Lanche> Lanches { get; }
    IEnumerable<Lanche> LanchesPreferidos { get; }
    Lanche GetLancheById(int lancheId);
  }
}
