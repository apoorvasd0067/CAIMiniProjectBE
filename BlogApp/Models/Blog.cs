using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        public string Link { get; set;}

        [ForeignKey("User")]
        public string Email { get; set; }


        public User User { get; set; }

    }

   
}
