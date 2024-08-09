using GraduatePortalBusiness;
using GraduatePortalWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System;

namespace GraduatePortalWeb.Pages.Students
{
    [Authorize(Roles = "Professor")]
    [BindProperties]
    public class ViewStudentsModel : PageModel
    {
        public List<PersonView> Students { get; set; } = new List<PersonView>();
        public void OnGet()
        {
            PopulateStudents();
        }

        private void PopulateStudents()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT PersonId, FirstName, LastName, Email FROM Person " +
                    "INNER JOIN Role ON Person.RoleId = Role.RoleId " +
                    "WHERE Role.RoleName = 'Student'";
                SqlCommand cmd = new SqlCommand(cmdText, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var student = new PersonView();

                        student.PersonId = reader.GetInt32(0);
                        student.FirstName = reader.GetString(1);
                        student.LastName = reader.GetString(2);
                        student.Email = reader.GetString(3);

                        Students.Add(student);
                    }
                }
            }
        }
    }
}
