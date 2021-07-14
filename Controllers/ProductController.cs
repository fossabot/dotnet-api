using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		public IRepository _repository { get; }
		public ProductController(IRepository repository)
		{
			_repository = repository;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var result = await _repository.GetAllProductsAsync();
				return Ok(result);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
			}
		}
		[HttpGet("{ProductId}")]
		public async Task<IActionResult> GetByProductId(int ProductId)
		{
			try
			{
				var result = await _repository.GetProductAsyncById(ProductId);
				return Ok(result);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
			}
		}
		[HttpPost]
		public async Task<IActionResult> post(Product model)
		{
			try
			{
				_repository.Add(model);
				if (await _repository.SaveChangesAsync())
				{
					return Created($"/api/product/{model.Id}", model);
				}
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
			}
			return BadRequest();
		}
		[HttpPut("{ProductId}")]
		public async Task<IActionResult> put(int ProductId, Product model)
		{
			try
			{
				var product = await _repository.GetProductAsyncById(ProductId);
				if (product == null)
					return NotFound();
				_repository.Update(model);
				if (await _repository.SaveChangesAsync())
				{
					product = await _repository.GetProductAsyncById(ProductId);
					return Created($"/api/product/{model.Id}", product);
				}
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
			}
			return BadRequest();
		}
		[HttpDelete("{ProductId}")]
		public async Task<IActionResult> delete(int ProductId)
		{
			try
			{
				var product = await _repository.GetProductAsyncById(ProductId);
				if (product == null)
					return NotFound();
				_repository.Delete(product);
				if (await _repository.SaveChangesAsync())
				{
					return Ok();
				}
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
			}
			return BadRequest();
		}
	}
}
