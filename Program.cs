using SalaoDeBeleza.Model.Data;
using SalaoDeBeleza.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<AppDbContext, AppDbContext>();
builder.Services.AddTransient<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddTransient<IServicoRepository, ServicoRepository>();
builder.Services.AddTransient<IManutencaoRepository, ManutencaoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(c =>

{

    c.WithOrigins("http://localhost:3000");

    c.AllowAnyHeader();

    c.AllowAnyMethod();

    c.AllowAnyOrigin();

});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
