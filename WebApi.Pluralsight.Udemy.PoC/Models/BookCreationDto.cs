using System.ComponentModel.DataAnnotations;
using WebApi.Pluralsight.Udemy.PoC.ValidationAttributes;

namespace WebApi.Pluralsight.Udemy.PoC.Models
{
    [BookTitleMustBeDifferentFromDescription]
    public class BookCreationDto /*: IValidatableObject*/
    {
        [Required(ErrorMessage = "You should fill out a title.")]
        [MaxLength(100, ErrorMessage = "The title should't have more than 100 characters.")]
        public string Title { get; set; }

        [MaxLength(1500, ErrorMessage = "The description shouldn't have more than 1500 characters.")]
        public string Description { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Description)
        //    {
        //        yield return new ValidationResult("The provided description should be different from the title.",
        //            new[] { "BookCreationDto" });
        //    }
        //}
    }
}
