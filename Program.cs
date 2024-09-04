using BibliotecaWeb.Database;
using BibliotecaWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BibliotecaDbContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DbPath")
));

//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<BibliotecaDbContext>();
        context.Database.EnsureCreated();
        if (!context.Livros.Any())
        {
            context.Livros.AddRange(
                new Livro { Titulo = "Livro Exemplo 1", Autor = "Autor Exemplo 1" },
                new Livro { Titulo = "Livro Exemplo 2", Autor = "Autor Exemplo 2" }
            );
            context.SaveChanges();
        }
    }

app.Run();
