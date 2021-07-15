using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace backend.Models
{
	public class Category
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public List<Product> Products { get; set; }
	}
}
