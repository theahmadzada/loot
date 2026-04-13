using FluentValidation;
using Loot.Application.Commands;
using Loot.Infrastructure.Consumers;
using Loot.Infrastructure.DbContext;
using Loot.Shared.Settings;
using Loot.WebApi;
using Loot.WebApi.Endpoints.User;
using Loot.WebApi.ExceptionHandler;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.ConfigureMediatr();
builder.AddMassTransitRabbitMq("loot-rabbitmq", massTransitConfiguration: cfg =>
{
    cfg.AddConsumer<ConfirmationEmailConsumer>();
});
builder.AddNpgsqlDbContext<LootDbContext>("loot-db");
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
builder.Services.ConfigureServices();
builder.Services.AddOptions<EmailSettings>()
    .BindConfiguration(EmailSettings.SectionName)
    .ValidateDataAnnotations()
    .ValidateOnStart();
builder.Services.AddOptions<JwtSettings>()
    .BindConfiguration(JwtSettings.SectionName)
    .ValidateDataAnnotations()
    .ValidateOnStart();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.RegisterUserEndpoints();
app.Run();