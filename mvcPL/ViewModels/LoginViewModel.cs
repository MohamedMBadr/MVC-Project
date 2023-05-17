using System.ComponentModel.DataAnnotations;

namespace MVC.PL.ViewModels
{
	public class LoginViewModel
	{

		[Required(ErrorMessage = "Email is Required ")]
		[EmailAddress(ErrorMessage = "Email not Valid")]
		public string Email { get; set; }


		[Required(ErrorMessage = "Passwod is Required ")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RememberMe { get; set; }

	}
}
