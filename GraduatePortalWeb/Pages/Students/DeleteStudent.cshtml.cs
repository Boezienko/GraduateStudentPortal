using GraduatePortalBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GraduatePortalWeb.Pages.Students
{
    [Authorize(Roles = "Professor")]
    public class DeleteStudentModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            // Delete person from the database
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Person WHERE PersonId = @personId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@personId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewStudents");
            }
        }
    }
}
