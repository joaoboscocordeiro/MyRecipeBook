using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Exception;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserAccountValidator : AbstractValidator<RequestRegisterUserAccountJson>
{
    public RegisterUserAccountValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMesageException.VALIDATE_NAME_REQUIRED);
        RuleFor(user => user.Email).NotEmpty().WithMessage("O email não pode ser vazio!");
        RuleFor(user => user.Password).NotEmpty().WithMessage("A senha não pode ser vazia!");
        When(user => string.IsNullOrWhiteSpace(user.Email) == false, () =>
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage("O email deve ser válido!");
        });
    }
}
