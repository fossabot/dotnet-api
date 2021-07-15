using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
	public class Product
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public double Price { get; set; }
		[Required]
		public int CategoryId { get; set; }

		public Category Categories { get; set; }

	}
}
