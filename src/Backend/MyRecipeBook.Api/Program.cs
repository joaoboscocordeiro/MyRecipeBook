using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using MyRecipeBook.Api.Filters;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportCultures = new List<CultureInfo> { new("en"), new("pt-BR"), new("es") };

    options.DefaultRequestCulture = new RequestCulture("en");

    options.SupportedCultures = supportCultures;
    options.SupportedUICultures = supportCultures;

    options.RequestCultureProviders = [ new AcceptLanguageHeaderRequestCultureProvider() ];
});

MyRecipeBook.Infrastructure.DependencyInjectionExtension.AddInfrastructure(builder.Services);
MyRecipeBook.Application.DependencyInjectionExtension.AddApplication(builder.Services);

var app = builder.Build();

var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestLocalization(localizationOptions.Value);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
