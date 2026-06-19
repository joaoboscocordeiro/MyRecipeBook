using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using MyRecipeBook.Infrastructure.Secutiry.PasswordHashing;

namespace MyRecipeBook.Infrastructure;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(config =>
            {
                config.UseMySQL(configuration.GetConnectionString("DefaultConnection")!);
            });
        }
    }
}
