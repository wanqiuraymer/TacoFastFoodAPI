using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.DAL
{
	public class UsersRepository
	{
		private static FastFoodTacoDbContext _context;
		static UsersRepository()
		{
			_context = new FastFoodTacoDbContext();
		}
		public static bool ValidateKey(string apiKey)
		{
			User user = _context.Users.FirstOrDefault(x => x.ApiKey == apiKey);
			return user != null;

		}
	}
}
