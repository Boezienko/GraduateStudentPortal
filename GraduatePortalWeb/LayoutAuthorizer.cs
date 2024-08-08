using System.Security.Claims;

namespace GraduatePortalWeb
{
    public class LayoutAuthorizer
    {
        static public string GetLayoutFromRole(HttpContext httpContext)
        {
            string layout = "_Layout";
            string userRole = httpContext.User.FindFirstValue(ClaimTypes.Role).ToString();
            if (userRole.Equals("Professor"))
            {
                layout = "_LayoutProfessor"; // Layout for patients
            }
            else if (userRole.Equals("Student"))
            {
                layout = "_LayoutStudent"; // Layout for nurses
            }
            
            return layout;
        }
    }
}
