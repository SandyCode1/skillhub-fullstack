//using FastEndpoints.Swagger;
//using FastEndpoints;
//using Microsoft.EntityFrameworkCore;
//using SkillHub.Application.Interfaces;
//using SkillHub.Infrastructure.Persistence;
//using SkillHub.Infrastructure.Services;
//using Npgsql;


//var builder = WebApplication.CreateBuilder(args);

//// Add CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowFrontend", policy =>
//    {
//        policy.WithOrigins("http://localhost:5174") // Your frontend's origin
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

////builder.Services.AddDbContext<AppDbContext>(options =>
////    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IUserService, UserService>();
////builder.Services.AddFastEndpoints();

//builder.Services
//    .AddFastEndpoints()
//    .SwaggerDocument(o =>
//    {
//        o.DocumentSettings = s =>
//        {
//            s.Title = "SkillHub API";
//            s.Version = "v1";
//        };
//    });

//var app = builder.Build();

//// Use CORS
//app.UseCors("AllowFrontend");

//app.UseFastEndpoints();
//app.UseSwaggerGen();
//app.Run();


using FastEndpoints.Swagger;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SkillHub.Application.Interfaces;
using SkillHub.Infrastructure.Persistence;
using SkillHub.Infrastructure.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5174") // Your frontend's origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Database connection setup (choose correct one)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  // SQL Server example
// or if using PostgreSQL:
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IUserService, UserService>();

// FastEndpoints setup and Swagger documentation generation
builder.Services.AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "SkillHub API";
            s.Version = "v1";
        };
    });

var app = builder.Build();

// Use CORS
app.UseCors("AllowFrontend");

app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();
