using Microsoft.AspNetCore.Mvc;
using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.DAL
{
	public class CombosRepository
	{
		private readonly FastFoodTacoDbContext _context;
		public CombosRepository(FastFoodTacoDbContext fastFoodTacoDbContext)
		{
			_context = fastFoodTacoDbContext;
		}

		public List<Combo> GetAllCombos()
		{
			return _context.Combos.ToList();
		}

		public Combo GetComboById(int id)
		{
			return _context.Combos.FirstOrDefault(x => x.ComboId == id);
		}

		public void AddCombo(Combo combo)
		{
			_context.Combos.Add(combo);
			_context.SaveChanges();
		}

		public void DeleteCombo(int id)
		{
			Combo combo = GetComboById(id);
			_context.Remove(combo);
			_context.SaveChanges();
		}

		
	}
}
