using System.ComponentModel.DataAnnotations;

namespace Employee_Mannagement.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }
        
        [Required(ErrorMessage = "FirstName is Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Firstname length must be 5 to 30")]
        public string? FirstName { get; set; }


        [Required(ErrorMessage = "LastName is Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Lastname length must be 5 to 30")]
        public string? LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string? Email { get; set; }

        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Please Select Designation")]
        public string? Designation { get; set; }

        [Required(ErrorMessage = "Please Select Education")]
        public string? Education { get; set; }

        [Required(ErrorMessage = "Please Select Project")]
        public string? Project { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public string? Country { get; set; }

        

        public DateTime EmpCreatedOn { get; set; }

    }
}
