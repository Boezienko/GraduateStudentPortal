using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GraduatePortalWeb.Model;
using GraduatePortalBusiness;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace GraduatePortalWeb.Pages.Grades
{
    [Authorize(Roles = "Professor, Student")]
    [BindProperties]
    public class ViewGradesModel : PageModel
    {
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public PersonProfile Student = new PersonProfile();

        public void OnGet(int id)
        {
            PopulateStudent(id);
            PopulateGrades(id);
        }

        private void PopulateStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName FROM Person " +
                    "WHERE PersonId = @personId";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("personId", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var student = new PersonView();

                        student.PersonId = id;
                        student.FirstName = reader.GetString(0);
                        student.LastName = reader.GetString(1);
                    }
                }
            }
        }

        private void PopulateGrades(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT [Grade].GradeId, [Grade].ClassId, [Grade].Grade, [Class].ClassName FROM Grade " +
                    "INNER JOIN Class ON [Grade].ClassId = [Class].ClassId " +
                    "WHERE [Grade].PersonId = @personId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("personId", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var grade = new Grade();

                        grade.PersonId = id;
                        grade.GradeId = reader.GetInt32(0);
                        grade.ClassId = reader.GetInt32(1);
                        grade.LetterGrade = reader.GetString(2);
                        grade.ClassName = reader.GetString(3);

                        Grades.Add(grade);
                    }
                }
            }
        }
    }
}
