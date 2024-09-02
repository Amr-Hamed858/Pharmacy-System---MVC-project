using Day_6.Contexts;
using System.ComponentModel.DataAnnotations;

namespace Day_6.Helpers
{
    public class UniqueCompanyNameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ProductContext productContext = validationContext.GetService<ProductContext>();

            string name =(string)value;

            if (productContext.Companies.Any(c => c.Name == name))
            {
                return new ValidationResult(ErrorMessage = "This company name already exists");
            }
            return ValidationResult.Success;
        }
    }
}
