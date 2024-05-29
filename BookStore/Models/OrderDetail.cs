using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
	public class OrderDetail
	{
		[Key]
		public int OrderDetailId { get; set; }
		public int OrderId { get; set; }
		public int WorkId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public virtual Work Work { get; set; }
		public virtual Order Order { get; set; }
	}
}
