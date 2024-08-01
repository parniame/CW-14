using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class BookViewModel
    {
        
        [StringLength(30,MinimumLength = 3,ErrorMessage ="Length should be between 3 to 30 letters")]
        public string Title { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Length should be between 3 to 30 letters")]
        public string Author { get; set; }
        public DateOnly PublishDate { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "should be positive!")]
        public int Price {  get; set; }



    }
}
