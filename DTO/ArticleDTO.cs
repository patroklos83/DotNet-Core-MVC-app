using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace WebApplicationExample.DTO
{
    public class ArticleDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "* Title input needed")]
        [DataType(DataType.Text)]
        //[MinLength(7)]
        //[MaxLength(20)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "* Author input needed")]
        [DataType(DataType.Text)]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        //[MinLength(7)]
        //[MaxLength(20)]
        public string? Author { get; set; }
        public int IsDeleted { get; set; }
    }
}
