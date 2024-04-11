using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ToDoListWebMVC.Data;
using ToDoListWebMVC.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<ToDoListWebMVCContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ToDoListWebMVCContext") 
            ?? throw new InvalidOperationException("Connection string 'ToDoListWebMVCContext' not found.")));
    builder.Services.AddControllersWithViews();
    builder.Services.AddScoped<SeedingService>();
    builder.Services.AddScoped<ToDoTaskService>();
}


var app = builder.Build();

var ptBR = new CultureInfo("pt-BR");
var localizationSettings = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ptBR),
    SupportedCultures = [ptBR],
    SupportedUICultures = [ptBR]
};

app.UseRequestLocalization(localizationSettings);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();





