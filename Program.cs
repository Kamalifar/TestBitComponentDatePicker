using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Localization;
using TestBitComponentDatePicker.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


app.Use(async (context, next) =>
{
    var culture = new CultureInfo("fa-IR");// Set user culture here
    CultureInfo.CurrentCulture = culture;
    CultureInfo.CurrentUICulture = culture;
    CultureInfo.DefaultThreadCurrentCulture = culture;
    CultureInfo.DefaultThreadCurrentUICulture = culture;
    // Call the next delegate/middleware in the pipeline
    await next();
});

//var localizeoptions = new RequestLocalizationOptions()
//    .SetDefaultCulture("en-US");
//app.UseRequestLocalization(localizeoptions);

//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    var CultureInfo = "fa-IR";
//    var supportedCultures = new[] { new CultureInfo(CultureInfo) };

//    options.DefaultRequestCulture = new RequestCulture(CultureInfo);

//    options.SupportedCultures = supportedCultures;
//    options.SupportedUICultures = supportedCultures;
//});

//builder.Services.AddLocalization();
//app.UseRequestLocalization("fa-IR");