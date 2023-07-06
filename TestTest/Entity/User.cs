using Microsoft.VisualBasic;

namespace TestTest.Entity
{
    public class User
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Created { get; set; }
        public int Personal_id { get; set; }
        public Personal Personal { get; set; }

    }
}
