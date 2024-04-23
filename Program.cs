using ApplicationsApi.Data;
using ApplicationsApi.Models;
using ApplicationsApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigins",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:DefaultValue"]);
});

builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IApplication,ApplicationService>();
var app = builder.Build();
app.MapIdentityApi<ApplicationUser>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//app.UseCors();
app.UseCors("AllowOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/applications", async(IApplication appRepo) =>
{
    return await appRepo.GetApplications();
})
.WithName("GetApplications")
.WithOpenApi()
.RequireAuthorization();


app.MapGet("/applications/{id:int}", async (int id,IApplication appRepo) =>
{
    return await appRepo.GetApplicationById(id);
})
.WithName("GetByIdApplications")
.WithOpenApi()
.RequireAuthorization();

app.MapPost("/applications",async(HttpContext http,Application application, IApplication appRepo, ApplicationDbContext dbContext) =>
{
    application.Orner = (ApplicationUser)await dbContext.Users.FirstOrDefaultAsync(u => u.Email == http.User.Identity.Name);
    return await appRepo.PostApplication(application);
})
.WithName("PostApplications")
.WithOpenApi()
.RequireAuthorization();

app.MapPut("/applications/{id:int}",async (IApplication appRepo,int id,Application application) =>
{
    application.Id= id;
    return await appRepo.PutApplication(id,application);
})
.WithName("UpdateApplications")
.WithOpenApi()
.RequireAuthorization();


app.MapDelete("/applications/{id:int}",async(int id, IApplication appRepo) =>
{
    return await appRepo.DeleteApplication(id);
})
.WithName("DeleteApplications")
.WithOpenApi()
.RequireAuthorization();


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
