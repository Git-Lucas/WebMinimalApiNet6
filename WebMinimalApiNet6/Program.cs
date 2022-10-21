using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMinimalApiNet6.Data;
using WebMinimalApiNet6.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

//GET, PASSANDO COMO PARÂMETRO O OBJETO DO MEU BANCO DE DADOS, E RETORNANDO (COMO É EM UMA LINHA), O STATUS 200 COM A LISTA COMPLETA DAS MINHAS TAREFAS
app.MapGet("/", (DataContext context) =>
    Results.Ok(context.Tarefas.AsNoTracking().ToList()));
////RequireAuthorization(), nas MinimalAPIs, é uma função do RouteHandlerBuilder
//app.MapGet("/", (DataContext context) => Results.Ok(context.Tarefas.AsNoTracking().ToList())).RequireAuthorization();
app.MapGet("/{id:int}", (DataContext context, int id) =>
    Results.Ok(context.Tarefas.AsNoTracking().FirstOrDefault(x => x.Id == id)));

app.MapPost("/", (DataContext context, [FromBody] Tarefa tarefa) =>
{
    try
    {
        context.Tarefas.Add(tarefa);
        context.SaveChanges();
        return Results.Created($"/{tarefa.Id}", tarefa);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPut("/{id:int}", (DataContext context, int id, [FromBody] Tarefa tarefa) =>
{
    try
    {
        var tarefaBanco = context.Tarefas.FirstOrDefault(x => x.Id == id);
        if (tarefaBanco == null)
            return Results.NotFound();

        tarefaBanco.Titulo = tarefa.Titulo;
        tarefaBanco.Feito = tarefa.Feito;

        context.Tarefas.Update(tarefaBanco);
        context.SaveChanges();
        return Results.Ok(tarefaBanco);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/{id:int}", (DataContext context, int id) =>
{
    try
    {
        var tarefaBanco = context.Tarefas.FirstOrDefault(x => x.Id == id);
        if (tarefaBanco == null)
            return Results.NotFound();

        context.Remove(tarefaBanco);
        context.SaveChanges();
        return Results.Ok(tarefaBanco);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});


app.Run();