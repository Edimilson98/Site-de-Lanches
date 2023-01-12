using Microsoft.AspNetCore.Mvc;
using TopLanches.Models;
using TopLanches.ViewModels;

namespace TopLanches.Components
{
  public class CarrinhoCompraResumo : ViewComponent
  {
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
    {
      _carrinhoCompra = carrinhoCompra;
    }

    public IViewComponentResult Invoke()
    {
      var itens = _carrinhoCompra.GetCarrinhoCompraItens();

      _carrinhoCompra.CarrinhoCompraItems = itens;

      var carrinhoCompraVM = new CarrinhoViewModel
      {
        CarrinhoCompra = _carrinhoCompra,
        CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
      };

      return View(carrinhoCompraVM);
    }
  }
}
