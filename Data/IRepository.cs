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
		Task<Product[]> GetAllProductsAsync();
		Task<Product> GetProductAsyncById(int ProductId);
	}
}
