using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int WorkId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Work Work { get; set; }

    }
}
