using GraduatePortalWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using GraduatePortalBusiness;

namespace GraduatePortalWeb.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public PersonRegister newPerson { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (EmailDNE(newPerson.Email))
                {
                    RegisterUser();
                    return RedirectToPage("Login");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "email already in use");
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError("RegisterError", "model not valid");
                return Page();
            }
        }

        private void RegisterUser()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                // create insert command
                string cmdText = "INSERT INTO Person(PersonId, FirstName, LastName, PasswordHash, Email, RoleId)" +
                    "VALUES(@personId, @firstName, @lastname, @passwordHash, @email, 0)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("personId", newPerson.PersonId);
                cmd.Parameters.AddWithValue("firstName", newPerson.FirstName);
                cmd.Parameters.AddWithValue("lastName", newPerson.LastName);
                cmd.Parameters.AddWithValue("email", newPerson.Email);
                cmd.Parameters.AddWithValue("passwordHash", SecurityHelper.GeneratePasswordHash(newPerson.Password));

                // open the database
                conn.Open();

                // execute the command
                cmd.ExecuteNonQuery();

                // close the database
                conn.Close();
            }
        }

        private bool EmailDNE(string email)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
    }
}
