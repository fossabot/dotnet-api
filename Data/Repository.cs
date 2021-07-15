using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using System.Threading.Tasks;

namespace backend.Data
{
	public class Repository : IRepository
	{
		public ApplicationDbContext _context { get; }
		public Repository(ApplicationDbContext context)
		{
			_context = context;
		}
		public void Add<T>(T entity) where T : class
		{
			_context.Add(entity);
		}
		public void Update<T>(T entity) where T : class
		{
			_context.Update(entity);
		}
		public void Delete<T>(T entity) where T : class
		{
			_context.Remove(entity);
		}
		public async Task<bool> SaveChangesAsync()
		{
			return (await _context.SaveChangesAsync() > 0);
		}
		public async Task<Product[]> GetAllProductsAsync(bool includeCategory = false)
		{
			IQueryable<Product> query = _context.Products;
			if (includeCategory)
			{
				query = query.Include(c => c.Categories);
			}
			query = query.AsNoTracking().OrderBy(p => p.Id);
			return await query.ToArrayAsync();
		}
		public async Task<Product> GetProductAsyncById(int ProductId, bool includeCategory)
		{
			IQueryable<Product> query = _context.Products;
			if (includeCategory)
			{
				query = query.Include(c => c.Categories);
			}
			query = query.AsNoTracking().OrderBy(product => product.Id).Where(product => product.Id == ProductId);
			return await query.FirstOrDefaultAsync();
		}
		public async Task<Category[]> GetCategoryAsync(bool includeProduct = false)
		{
			IQueryable<Category> query = _context.Categories;
			if (includeProduct)
			{
				query = query.Include(p => p.Products);
			}
			query = query.AsNoTracking().OrderBy(c => c.Id);
			return await query.ToArrayAsync();
		}
		public async Task<Category> GetCategoryById(int CategoryId, bool includeProduct)
		{
			IQueryable<Category> query = _context.Categories;
			if (includeProduct)
			{
				query = query.Include(p => p.Products);
			}
			query = query.AsNoTracking().OrderBy(category => category.Id).Where(category => category.Id == CategoryId);
			return await query.FirstOrDefaultAsync();
		}
	}
}
