using ClientManagerAPI.Infrastructure.Data;
using ClientManagerAPI.Infrastructure.Auth;
using ClientManagerAPI.Infrastructure.Repositories;
using ClientManagerAPI.Application.Interfaces;
using ClientManagerAPI.Presentation.Extensions;
using ClientManagerAPI.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// 🔐 Configuración JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

// 📦 Agregar servicios, repos y handlers
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<CrearClienteHandler>();
builder.Services.AddScoped<ActualizarClienteHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithJwt();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ClientesDb")); // o SQLServer según env

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
