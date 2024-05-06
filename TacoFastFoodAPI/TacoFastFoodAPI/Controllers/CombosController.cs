using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFoodAPI.DAL;
using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CombosController : ControllerBase
	{
		private readonly CombosRepository _combosRepository;
		public CombosController(CombosRepository combosRepository)
		{
			_combosRepository = combosRepository;
		}

		[HttpGet]
		public IActionResult GetAllCombos()
		{
			List<Combo> combos=_combosRepository.GetAllCombos();
			return Ok(combos);
		}

		[HttpGet("{id}")]
		public IActionResult GetComboById(int id)
		{
			Combo combo = _combosRepository.GetComboById(id);
			if (combo == null)
			{
				return NotFound();
			}
			return Ok(combo);
		}
		[HttpPost]
		public IActionResult AddCombo([FromBody] ComboCreateDto comboCreateDto)
		{
			Combo combo = new Combo()
			{
				ComboName = comboCreateDto.ComboName,
				TacoId = comboCreateDto.TacoId,
				DrinkId = comboCreateDto.DrinkId,
				Cost = comboCreateDto.Cost
			};
			_combosRepository.AddCombo(combo);
			return Created();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCombo(int id)
		{
			Combo combo = _combosRepository.GetComboById(id);
			return combo == null ? NotFound() : NoContent();
			
		}

	}
}
