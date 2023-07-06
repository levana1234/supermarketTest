using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Text;
using TestTest.Entity;

namespace TestTest.Repozitory
{
    public class authRepozitory : IauthRepozitorycs
    {
        public readonly MarketDbContext _context;
        public authRepozitory(MarketDbContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.users.Include(x=> x.Personal).FirstOrDefaultAsync(x=> x.UserName == username);

            if (user == null)
            {
                return null;
            }

            if(!VerifyPaswordHush(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;


        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHush, passwordSalt;

            CreatePaswordHush(password, out passwordHush, out passwordSalt);

            user.PasswordHash = passwordHush;
            user.PasswordSalt = passwordSalt;

           await _context.users.AddAsync(user);
           await _context.personals.AddAsync(user.Personal);
            
           await _context.SaveChangesAsync();
            return user;
            
            
        }

        public async Task<bool> UserExits(string username)
        {
          return  await _context.users.AnyAsync(x=> x.UserName == username);
        }

        private bool VerifyPaswordHush (string password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i =  0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != PasswordHash[i])
                    {
                        return false;
                    }
                }
                return true;

            }
            

        }


        private bool CreatePaswordHush(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key; 
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                
                return true;

            }
            


        }

        public async Task<User> ChangePassword(string username, string password, string NewUserName, string Newpassord)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                return null;
            }


            if (!verufypassword(password, Newpassord,  user.PasswordHash,  user.PasswordSalt))
            {
                return null;
            }

            byte[] hush, salt;

            Createpass(Newpassord, out hush, out salt);

            user.UserName = NewUserName;
            user.PasswordHash = hush;
            user.PasswordSalt = salt; 
            
            _context.users.Update(user);

            _context.SaveChanges();


            return user;

            

        }

        public bool verufypassword (string password, string newpassword, byte[] PasswordHash,  byte[] PasswordSalt)
        {
            var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt);

            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            for (var i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != PasswordHash[i])
                {
                    return false;
                }
            }

             return true;


        }


        public bool Createpass(string newpassword,  out byte[] PasswordHash , out byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(newpassword));


                return true;

            }

        }



    }
}
