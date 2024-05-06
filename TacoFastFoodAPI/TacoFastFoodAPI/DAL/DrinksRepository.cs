using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.DAL
{
	public class DrinksRepository
	{
		private readonly FastFoodTacoDbContext _context;
		public DrinksRepository(FastFoodTacoDbContext fastFoodTacoDbContext)
		{
			_context = fastFoodTacoDbContext;
		}

		public List<Drink> GetAllDrinks()
		{
			return _context.Drinks.ToList();
		}

		public Drink GetDrinkById(int id)
		{
			return _context.Drinks.FirstOrDefault(x => x.DrinkId == id);

		}

		public void AddDrink(Drink drink)
		{
			_context.Drinks.Add(drink);
			_context.SaveChanges();
		}

		public void UpdateDrink(Drink drink)
		{
			_context.Drinks.Update(drink);
			_context.SaveChanges();
		}
	}
}
