namespace TacoFastFoodAPI.Models
{
	public class ComboCreateDto
	{
		public string ComboName { get; set; }

		public float Cost { get; set; }

		public int TacoId { get; set; }

		public int DrinkId { get; set; }
	}
}
