using System.ComponentModel.DataAnnotations;

namespace BookManager.Models
{
    public class Book
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int YearPublished { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Number of pages must be greater than 0.")]
        public int NumberOfPages { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}