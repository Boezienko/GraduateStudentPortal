using System.ComponentModel.DataAnnotations;

namespace GraduatePortalWeb.Model
{
    public class PersonView
    {
        [Display(Name = "SFA ID: ")]
        public int PersonId { get; set; }
        /////////////////////////////////////////////////////////////
        [Display(Name = "First name: ")]
        public string FirstName { get; set; }
        /////////////////////////////////////////////////////////////
        [Display(Name = "Last name: ")]
        public string LastName { get; set; }
        /////////////////////////////////////////////////////////////
        [Display(Name = "Email: ")]
        public string Email { get; set; }

    }
}
