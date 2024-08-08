using GraduatePortalBusiness;
using GraduatePortalWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace GraduatePortalWeb.Pages.Students
{
    public class AddStudentModel : PageModel
    {
        [BindProperty]
        public PersonRegister newStudent { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()

        {
            if (ModelState.IsValid)
            {
                // Check if email already exists in DB

                if (EmailDNE(newStudent.Email)) //DNE - Does Not Exist
                {
                    RegisterUser();
                    return RedirectToPage("ViewStudents");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "The email address already exists, please try another.");
                    return Page();
                }

            }
            else
            {
                return Page();
            }
        }
        private void RegisterUser()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                //2. Create a insert command
                string cmdText = "INSERT INTO Person(PersonId, FirstName, LastName, Email, PasswordHash, RoleId)" +
                    "VALUES(@personId, @firstName, @lastName, @email, @password, @roleId)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@personId", newStudent.PersonId);
                cmd.Parameters.AddWithValue("@firstName", newStudent.FirstName);
                cmd.Parameters.AddWithValue("@lastName", newStudent.LastName);
                cmd.Parameters.AddWithValue("@email", newStudent.Email);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratePasswordHash(newStudent.Password));
                cmd.Parameters.AddWithValue("@roleId", 1);

                //3. Open the database 
                conn.Open();
                //4.Execute the command 
                cmd.ExecuteNonQuery();
                //5. Close the database
                conn.Close();
            }
        }

        private bool EmailDNE(string email) // Check given email. If it already exists ret false. Otherwise ret true.
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
