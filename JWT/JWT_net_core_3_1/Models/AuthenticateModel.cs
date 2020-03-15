using System.ComponentModel.DataAnnotations;

namespace Auth0_net_core_3_1.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
