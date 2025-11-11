using Microsoft.AspNetCore.Diagnostics;
using Repository;
using Service;
using Microsoft.OpenApi.Interfaces;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositórios (em memória - listas)
builder.Services.AddSingleton<ILivroRepository, LivroRepository>();
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddSingleton<IEmprestimoRepository, EmprestimoRepository>();

// Relatórios depende do repositório de empréstimos
builder.Services.AddSingleton<IRelatorioRepository, RelatorioRepository>();

// Serviços
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEmprestimoService, EmprestimoService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? "Server=localhost;Database=fiap;User=root;Password=123;Port=3306;";

var app = builder.Build();

// Swagger no modo de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware global de erros
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var exception = context.Features.Get<IExceptionHandlerFeature>();
        if (exception != null)
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError(exception.Error, "Erro não tratado capturado pelo middleware global");

            var errorResponse = new
            {
                message = "Erro interno do servidor",
                timestamp = DateTime.UtcNow,
                requestId = context.TraceIdentifier
            };

            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(errorResponse));
        }
    });
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
