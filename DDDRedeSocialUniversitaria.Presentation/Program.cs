using DDDRedeSocialUniversitaria.Infra;
using DDDRedeSocialUniversitaria.Infra.Interfaces;
using DDDRedeSocialUniversitaria.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;


namespace DDDRedeSocialUniversitaria.Presentation
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<SqlContext>();
            builder.Services.AddScoped<IEventosRepository, EventoRepository>();
            builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            using var app = builder.Build();

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
        }
    }
}