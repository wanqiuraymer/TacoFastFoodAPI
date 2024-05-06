using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.DAL
{
	public class TacosRepository
	{
		private readonly FastFoodTacoDbContext _context;
		public TacosRepository(FastFoodTacoDbContext fastFoodTacoDbContext)
		{
			_context = fastFoodTacoDbContext;
		}

		public List<Taco> GetAllTacos()
		{
			return _context.Tacos.ToList();
		}
		public Taco GetTacoById(int id)
		{
			Taco taco = _context.Tacos.FirstOrDefault(x => x.TacoId == id);			
			return taco;
		}
		public void AddTaco(Taco taco)
		{
			_context.Tacos.Add(taco);
			_context.SaveChanges();
		}
		public void DeleteTaco (int id)
		{
			Taco taco = GetTacoById(id);
			_context.Remove(taco);
			_context.SaveChanges();
		}
	}
}
