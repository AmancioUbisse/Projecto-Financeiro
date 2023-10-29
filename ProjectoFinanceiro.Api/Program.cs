using ProjectoFinanceiro.Infrastructure.Repositories;
using ProjectoFinanceiro.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Configurar a inje��o de depend�ncia
builder.Services.AddControllers();

// Adicionar servi�os
//Repositorios
builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();

//Servicos
builder.Services.AddScoped<ClienteService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
