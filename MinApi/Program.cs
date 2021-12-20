using Microsoft.EntityFrameworkCore;
using MinApi.Models;
using MinApi.Data;

var builder = WebApplication.CreateBuilder(args);

//Inyección de dependencias
builder.Services.AddDbContext<MinApi.Data.api_dbContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/colaboradores", async (api_dbContext context) =>
    await context.Colaboradores.ToListAsync()
    );
app.MapGet("/colaboradores/{id}", async (int id, api_dbContext context) =>
    {
        var colaborador = await context.Colaboradores.FindAsync(id);
        return colaborador != null ? Results.Ok(colaborador) : Results.NotFound();
    });

app.MapGet("viajes", async (api_dbContext context) =>
   await context.Viajes.ToListAsync()
    );
app.MapPost("/viajes/create", async (Viaje viaje, api_dbContext context) =>
{
    context.Viajes.Add(viaje);
    return context.SaveChangesAsync();
});
app.Run();
