using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace BookStore.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Work>? Works { get; set; }
        
    }
}