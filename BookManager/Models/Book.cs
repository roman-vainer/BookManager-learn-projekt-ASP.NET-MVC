using System.ComponentModel.DataAnnotations;

namespace BookManager.Models
{
    public class Book
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Title is required.")]
        public string? Title { get; set; }
        
        [Required(ErrorMessage = "Author is required.")]
        public string? Author { get; set; }
        
        public string? Genre { get; set; }

        [Range(1450, 2026, ErrorMessage = "Year published must be between 1450 and the current year.")]
        public int? YearPublished { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Number of pages must be greater than 0.")]
        public int NumberOfPages { get; set; }

        public bool IsAvailable { get; set; } = true;
        
        public string? Description { get; set; }
        
        public string? ImagePath { get; set; }
    }
}