using Microsoft.Identity.Client;
using TestTest.Entity;

namespace TestTest.Repozitory
{
    public interface IauthRepozitorycs
    {
        Task<User> Register ( User user, string password); 
        Task<User> Login (string username, string password);
        Task<bool> UserExits (string username);

        Task<User> ChangePassword (string username, string password, string NewUserName, string Newpassord);
    }
}
