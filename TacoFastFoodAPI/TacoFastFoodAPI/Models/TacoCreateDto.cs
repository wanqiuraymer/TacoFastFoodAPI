namespace TacoFastFoodAPI.Models
{
	public class TacoCreateDto
	{
		public string TacoName { get; set; }

		public float Cost { get; set; }

		public bool SoftShell { get; set; }

		public bool Chips { get; set; }
	}
}
