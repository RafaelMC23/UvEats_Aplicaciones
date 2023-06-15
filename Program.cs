using UvEats_Aplicaciones.Business;
var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;
var urlAPI = config["UrlAPI"];
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<ILoginProvider,LoginWSProvider>();

builder.Services.AddHttpClient("api", client =>
    {
        client.BaseAddress = new Uri(urlAPI);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        
    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
app.MapRazorPages();

app.Run();
