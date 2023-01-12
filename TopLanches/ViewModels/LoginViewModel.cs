using System.ComponentModel.DataAnnotations;

namespace TopLanches.ViewModels
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "Informe o nome")]
    [Display(Name = "Usúario")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Informe a senha")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }
    public string ReturnUrl { get; set; }

  }
}
