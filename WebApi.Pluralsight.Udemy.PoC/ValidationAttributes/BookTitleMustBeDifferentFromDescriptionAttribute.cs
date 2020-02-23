using System.ComponentModel.DataAnnotations;
using WebApi.Pluralsight.Udemy.PoC.Models;

namespace WebApi.Pluralsight.Udemy.PoC.ValidationAttributes
{
    public class BookTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var book = (BookCreationDto)validationContext.ObjectInstance;

            if (book.Title == book.Description)
            {
                return new ValidationResult("The provided description should be different from the title.",
                    new[] { "BookCreationDto" });
            }

            return ValidationResult.Success;
        }
    }
}
