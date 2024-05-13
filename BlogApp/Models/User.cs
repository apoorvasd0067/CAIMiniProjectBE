using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class User
    {
        
       
        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Password { get; set; }

  
    }

    public class UserLoginCredentials
    {
        [Required]
        [EmailAddress]
        public  string Email { get; set; }

        [Required]
        /*[MinLength(8)]*/ // Enforce minimum password length for security
        public  string Password { get; set; }
    }

}

