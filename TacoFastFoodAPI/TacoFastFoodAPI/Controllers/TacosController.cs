using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFoodAPI.DAL;
using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TacosController : ControllerBase
	{
		private readonly TacosRepository _tacosRepository;
		public TacosController(TacosRepository tacosRepository)
		{
			_tacosRepository = tacosRepository;
		}

		[HttpGet]
		public IActionResult GetAllTaco()
		{
			List<Taco> tacos=_tacosRepository.GetAllTacos();
			return Ok(tacos);
		}

		[HttpGet("{id}")]
		public IActionResult GetTacoById(int id)
		{
			Taco taco = _tacosRepository.GetTacoById(id);
			if (taco == null)
			{
				return NotFound();
			}
			return Ok(taco);
		}

		[HttpPost]
		public IActionResult AddTaco([FromBody]TacoCreateDto tacoCreateDto)
		{
			Taco taco = new Taco()
			{
				TacoName = tacoCreateDto.TacoName,
				Chips = tacoCreateDto.Chips,
				SoftShell = tacoCreateDto.SoftShell,
				Cost = tacoCreateDto.Cost
			};
			_tacosRepository.AddTaco(taco);
			return Created();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteTaco(int id)
		{
			Taco taco = _tacosRepository.GetTacoById(id);
			if (taco == null) { return NotFound(); }
			return NoContent();
		}
	}
}
