using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesZenSpaCh7.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        [Display(Name = "First Name")]
        [Column("First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        [Column("Last Name")]
        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string State { get; set; } = string.Empty;
        [Display(Name = "Zipcode")]
        [Column("Zipcode")]
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}",
        ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}