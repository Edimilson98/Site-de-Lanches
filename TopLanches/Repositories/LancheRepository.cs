﻿using Microsoft.EntityFrameworkCore;
using TopLanches.Context;
using TopLanches.Models;
using TopLanches.Repositories.Interfaces;

namespace TopLanches.Repositories
{
  public class LancheRepository : ILancheRepository
  {
    private readonly AppDbContext _context;
    public LancheRepository(AppDbContext contexto)
    { 
      _context = contexto;
    }
    public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

    public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.
                                                                      Where(l => l.IsLanchePreferido)
                                                                    .Include(c => c.Categoria);

    public Lanche GetLancheById(int lancheId)
    {
      return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
    }
  }
}
