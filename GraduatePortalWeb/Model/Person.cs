using System.ComponentModel.DataAnnotations;

namespace GraduatePortalWeb.Model
{
    public class Person
    {
        [Required(ErrorMessage = "SFA ID is required")]
        [Display(Name = "SFA ID: ")]
        public int PersonId { get; set; }
        /////////////////////////////////////////////////////////////
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First name: ")]
        public string FirstName { get; set; }
        /////////////////////////////////////////////////////////////
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last name: ")]
        public string LastName { get; set; }
        /////////////////////////////////////////////////////////////
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password: ")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{10,}$", ErrorMessage = "Password must be at least 10 characters long and contain at least one number, one lowercase letter, and one uppercase letter.")]
        public string Password { get; set; }
        /////////////////////////////////////////////////////////////
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        /////////////////////////////////////////////////////////////
        public int RoleId {  get; set; }
    }
}
