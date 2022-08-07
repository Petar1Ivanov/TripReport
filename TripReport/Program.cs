using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TripReport.Data;
using TripReport.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TripDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

}).AddEntityFrameworkStores<TripDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    // app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var data = scope.ServiceProvider.GetRequiredService<TripDbContext>();
    data.Database.Migrate();
    SeedPayment(data);
    SeedDuration(data);
}
static void SeedPayment(TripDbContext data)
{
    if (data.Payment.Any())
    {
        return;
    }
    data.Payment.AddRange(new[]
    {
        new Payment {Name="В брой" },
        new Payment {Name="По банка" },
    });

    data.SaveChanges();
}
static void SeedDuration(TripDbContext data)
{
    if (data.Duration.Any())
    {
        return;
    }
    data.Duration.AddRange(new[]
    {
        new Duration {Name="1/2 час",Value=30 },
        new Duration {Name="1 час",Value=60 },
        new Duration {Name="1.5 часa",Value=90 },
        new Duration {Name="2.0 часa",Value=120 },
        new Duration {Name="2.5 часa",Value=150 },
        new Duration {Name="3.0 часa",Value=180 },
        new Duration {Name="3.5 часa",Value=210 },
        new Duration {Name="4.0 часa",Value=240 },
    });

    data.SaveChanges();
}




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
