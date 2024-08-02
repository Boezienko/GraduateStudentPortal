using BCrypt.Net;

namespace GraduatePortalBusiness
{
    public class SecurityHelper
    {

        public static string generatePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public static bool verifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash); 
        }

        public static string getDBConnectionString()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=GraduatePortalDB;Trusted_Connection=True;";
            return connString;
        }

    }
}
