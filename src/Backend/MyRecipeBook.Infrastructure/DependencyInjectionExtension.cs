using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Infrastructure.Secutiry.PasswordHashing;

namespace MyRecipeBook.Infrastructure;

public class DependencyInjectionExtension
{
    public static void AddInfrastructure(IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
    }
}
