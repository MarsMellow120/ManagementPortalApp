using System.ComponentModel.DataAnnotations;
namespace ManagementPortal.Models

{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the Start Date.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/9999", ErrorMessage = "Start Date must be after 1/1/1900.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(30, ErrorMessage = "Title must be 30 characters or less.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a Pay Rate.")]

        [DataType(DataType.Currency)]
        [Range(0, 100, ErrorMessage = "Please enter the Pay Rate between 0 and 100")]
        public decimal PayRate { get; set; }

        [Required(ErrorMessage = "Please enter the Hours.")]
        [Range(0, 100, ErrorMessage = "Please enter the hours between 0 and 100")]
        public decimal Hours { get; set; }

        [Required(ErrorMessage = "Please enter the Department.")]
        public string DepartmentId { get; set; } //Foreign key
        public Department Department { get; set; }
        public decimal CalculatePay()
        {
            return PayRate * Hours;
        }

    }
}
