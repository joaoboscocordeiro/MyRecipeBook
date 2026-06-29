using CommonTestUtilities.Requests;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Exception;
using Shouldly;

namespace Validators.Tests.User.Register;

public class RegisterUserAccountValidatorTests
{
    [Fact]
    public void Success()
    {
        // AAA => Arranger, Act, Assert

        // Arrange
        var request = RequestRegisterUserAccountJsonBuilder.Build();

        var validator = new RegisterUserAccountValidator();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenNameIsEmpty()
    {
        // AAA => Arranger, Act, Assert

        // Arrange
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Name = string.Empty;

        var validator = new RegisterUserAccountValidator();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourseMesageException.VALIDATE_NAME_REQUIRED));
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenEmailIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Email = string.Empty;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourseMesageException.VALIDATE_EMAIL_REQUIRED));
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenPasswordIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Password = string.Empty;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourseMesageException.VALIDATE_PASSWORD_REQUIRED));
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenEmailIsInvalid()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Email = "jr.com";

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourseMesageException.VALIDATE_EMAIL_INVALID));
        });
    }
}
