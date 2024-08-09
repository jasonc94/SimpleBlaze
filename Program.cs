using SimpleBlazorApp.Components;
using SimpleBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

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


static void ConfigureServices(IServiceCollection services)
{
	// Add services to the container.
	services.AddRazorComponents()
		.AddInteractiveServerComponents();

	services.AddBlazorBootstrap();

	services.AddSingleton<ITasksService, TasksService>();
}