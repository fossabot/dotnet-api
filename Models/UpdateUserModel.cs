using System.ComponentModel.DataAnnotations;

namespace backend.Models.Users
{
	public class UpdateUserModel
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
