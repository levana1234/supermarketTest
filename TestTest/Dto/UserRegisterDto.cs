using System.ComponentModel.DataAnnotations;

namespace TestTest.Dto
{
    public class UserRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]       
        
        public string Password { get; set; }
        public string Email { get; set; }
        //person

        public string Name { get; set; }
        public int Age { get; set; }

        public int marcetPersonID { get; set; }


    }
}
