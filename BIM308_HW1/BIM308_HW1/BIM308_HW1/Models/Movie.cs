using System.ComponentModel.DataAnnotations;

namespace BIM308_HW1.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Director { get; set; } 
        public string[]? Stars { get; set; } 
        public int ReleaseYear { get; set; }
        public string? ImageUrl { get; set; } 
    }
}