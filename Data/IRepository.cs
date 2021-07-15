using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
	public interface IRepository
	{
		void Add<T>(T entity) where T : class;
		void Update<T>(T entity) where T : class;
		void Delete<T>(T entity) where T : class;
		Task<bool> SaveChangesAsync();
		//Product
		Task<Product[]> GetAllProductsAsync(bool includeCategory);
		Task<Product> GetProductAsyncById(int ProductId, bool includeCategory);

		//Category
		Task<Category[]> GetCategoryAsync(bool includeProduct);
		Task<Category> GetCategoryById(int CategoryId, bool includeProduct);
	}
}
