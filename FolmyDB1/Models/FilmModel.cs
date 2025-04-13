using System.ComponentModel.DataAnnotations;

namespace FilmDB.Models
{
    public class FilmModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        public string Title { get; set; }

        public int Year { get; set; }
    }
}