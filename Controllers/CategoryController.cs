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
	public class CategoryController : ControllerBase
	{
		public IRepository _repo { get; }
		public CategoryController(IRepository repo)
		{
			_repo = repo;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var result = await _repo.GetCategoryAsync(true);
				return Ok(result);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro no banco de dados");
			}
		}
		[HttpGet("{CategoryId}")]
		public async Task<IActionResult> GetCategoryById(int CategoryId)
		{
			try
			{
				var result = await _repo.GetCategoryById(CategoryId, true);
				return Ok(result);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um eror no banco de dados");
			}
		}
		[HttpPost]
		public async Task<IActionResult> post(Category model)
		{
			try
			{
				_repo.Add(model);
				if (await _repo.SaveChangesAsync())
				{
					return Created($"/api/category/{model.Id}", model);
				}
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu uma falha no banco de dados");
			}
			return BadRequest();
		}
		[HttpPut("{CategoryId}")]
		public async Task<IActionResult> put(int CategoryId, Category model)
		{
			try
			{
				var category = await _repo.GetCategoryById(CategoryId, false);

				if (category == null)
					return NotFound();

				_repo.Update(model);

				if (await _repo.SaveChangesAsync())
				{
					category = await _repo.GetCategoryById(CategoryId, true);
					return Created($"/api/category/{category.Id}", category);
				}
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu uma falha no banco de dados falhou");
			}
			return BadRequest();
		}

		[HttpDelete("{CategoryId}")]
		public async Task<IActionResult> delete(int CategoryId)
		{
			try
			{
				var category = await _repo.GetCategoryById(CategoryId, false);

				if (category == null)
					return NotFound();

				_repo.Delete(category);

				if (await _repo.SaveChangesAsync())
				{
					category = await _repo.GetCategoryById(CategoryId, true);
					return Created($"/api/category/{category.Id}", category);
				}
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu uma falha no banco de dados falhou");
			}
			return BadRequest();
		}
	}
}
