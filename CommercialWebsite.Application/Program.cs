using CommercialWebsite.DataContext.Concrete;
using CommercialWebsite.DataContext.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDatabaseConfiguration>(new DatabaseConfiguration("Database"));
builder.Services.AddScoped<IClientRepository>((IServiceProvider serviceProvider) => 
                                                    new ClientRepository(serviceProvider.GetService<IDatabaseConfiguration>()));
builder.Services.AddScoped<IWebsiteFieldRepository>((IServiceProvider serviceProvider) => 
                                                    new WebsiteFieldRepository(serviceProvider.GetService<IDatabaseConfiguration>()));

// Add services to the container.
builder.Services.AddRazorPages();

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

app.MapRazorPages();

app.Run();
