using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Exception;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserAccountValidator : AbstractValidator<RequestRegisterUserAccountJson>
{
    public RegisterUserAccountValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourseMesageException.VALIDATE_NAME_REQUIRED);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourseMesageException.VALIDATE_EMAIL_REQUIRED);
        RuleFor(user => user.Password).NotEmpty().WithMessage(ResourseMesageException.VALIDATE_PASSWORD_REQUIRED);
        When(user => user.Email.IsNotEmpty(), () =>
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourseMesageException.VALIDATE_EMAIL_INVALID);
        });
    }
}
