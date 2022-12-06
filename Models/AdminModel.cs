using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee_Mannagement.Models
{
    public class AdminModel
    {
        [Required(ErrorMessage = "Username is Required")]
        [DisplayName("Username")]
        public string? AdminUsername { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        public string? AdminPassword { get; set; }
    }
}
