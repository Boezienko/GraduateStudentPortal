using BCrypt.Net;

namespace GraduatePortalBusiness
{
    public class SecurityHelper
    {

        public static string GeneratePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash); 
        }

        public static string GetDBConnectionString()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=GraduatePortalDB;Trusted_Connection=True;";
            return connString;
        }

    }
}
