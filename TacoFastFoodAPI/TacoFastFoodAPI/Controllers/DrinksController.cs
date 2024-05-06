using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TacoFastFoodAPI.DAL;
using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DrinksController : ControllerBase
	{
		private readonly DrinksRepository _drinksRepository;
		public DrinksController(DrinksRepository drinksRepository)
		{
			_drinksRepository = drinksRepository;
		}
		[HttpGet]
		public IActionResult GetAllDrinks(string apiKey, string sortByCost = null)
		{
			bool isValid = UsersRepository.ValidateKey(apiKey);
			if (isValid == false)
			{
				return Unauthorized();
			}
			List<Drink> drinks = _drinksRepository.GetAllDrinks();
			if (sortByCost != null)
			{
				if(sortByCost.ToLower() == "descending")
				{
					return Ok(drinks.OrderByDescending(x => x.Cost));
				}
				else if (sortByCost.ToLower() == "ascending")
				{
					return Ok(drinks.OrderBy(x => x.Cost));
				}
			}
			return Ok(drinks);
		}

		[HttpGet("{id}")]
		public IActionResult GetDrinkById([FromHeader(Name = "API-Key")]string apiKey, int id)
		{
			bool isValid = UsersRepository.ValidateKey(apiKey);
			if (isValid == false)
			{
				return Unauthorized();
			}
			Drink drink = _drinksRepository.GetDrinkById(id);
			return drink != null ? Ok(drink) : NotFound();
			/*if (drink != null)
			{
				return Ok(drink);
			}
			return NotFound();*/
		}

		[HttpPost]
		public IActionResult AddDrink([FromBody] DrinkCreateDto drinkCreateDto)
		{
			Drink drink = new Drink()
			{
				DrinkName = drinkCreateDto.DrinkName,
				Cost = drinkCreateDto.Cost,
				Slushie = drinkCreateDto.Slushie
			};
			_drinksRepository.AddDrink(drink);
			return Created();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateDrink(int id, [FromBody] DrinkCreateDto drinkCreateDto)
		{
			Drink drink = _drinksRepository.GetDrinkById(id);
			drink.DrinkName = drinkCreateDto.DrinkName;
			drink.Slushie = drinkCreateDto.Slushie;
			drink.Cost = drinkCreateDto.Cost;
			_drinksRepository.UpdateDrink(drink);
			return NoContent();
		}
		

	}
}
