using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Work
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Title { get; set; }
        [Range(0.01, 100.00,
           ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }
        [DisplayName("Book Picture URL")]
        [StringLength(1024)]
        public string BookPicture { get; set; }

        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }

        public int WriterId { get; set; }
        public virtual Writer? Writer { get; set; }
        
        public virtual List<OrderDetail>? OrderDetails { get; set; }


    }

}
