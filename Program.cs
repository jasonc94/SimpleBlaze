using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleBlazorApp.Components;
using SimpleBlazorApp.Config;
using SimpleBlazorApp.Data;
using SimpleBlazorApp.Helpers;
using SimpleBlazorApp.Repository;
using SimpleBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	// Add services to the container.
	services.AddRazorComponents()
		.AddInteractiveServerComponents();

	services.AddBlazorBootstrap();

	services.AddDbContext<SimpleBlazeContext>(options =>
	{
		options.UseSqlite(configuration.GetConnectionString("SqlLiteConnectionString"));
	});

	// Bind configuration settings to the GiphySettings class
	services.Configure<GiphyConfig>(configuration.GetSection("Giphy"));

	services.AddSingleton<GiphyDefaultQueryParam>(sp =>
	{
		var configuration = sp.GetRequiredService<IConfiguration>();
		return new GiphyDefaultQueryParam(configuration);
	});


	services.AddHttpClient("Giphy").AddHttpMessageHandler<GiphyDefaultQueryParam>();

	services.AddScoped<ITasksService, TasksService>();

	services.AddSingleton<IGiphyService, GiphyService>();

	services.AddScoped<ITaskRepository,  TaskRepository>();
}