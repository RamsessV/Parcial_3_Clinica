using Clinica.Components;
using Clinica.Data;
using Clinica.Repositories.Consultas;
using Clinica.Repositories.Doctores;
using Clinica.Repositories.Pacientes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ContextDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepositorioPacientes, RepositorioPacientes>();
builder.Services.AddScoped<IRepositorioDoctores, RepositorioDoctores>();
builder.Services.AddScoped<IRepositorioConsultas, RepositorioConsultas>();

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
