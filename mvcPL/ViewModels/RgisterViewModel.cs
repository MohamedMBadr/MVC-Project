using System.ComponentModel.DataAnnotations;

namespace MVC.PL.ViewModels
{
	public class RgisterViewModel
	{

		public string FName { get; set; }	
		public string LName { get; set; }	

		[Required (ErrorMessage = "Email is Required ")]
		[EmailAddress (ErrorMessage ="Email not Valid")]
		public string Email { get; set; }


		[Required(ErrorMessage = "Passwod is Required ")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Passwod is Required ")]
		[Compare("Password",ErrorMessage ="Confirm password does not match password")]
		[DataType(DataType.Password)]
		public string ConfirmPasswod { get; set; }


		public bool IsAgree { get; set; }	
	}
}

