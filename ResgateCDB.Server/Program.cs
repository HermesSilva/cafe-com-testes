using System.Diagnostics.CodeAnalysis;

using WebAPI.Injections;
namespace WebAPI
{

    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddMvc().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });
            // #if DEBUG
            builder.Services.AddSwaggerGen();
            // #endif
            builder.Services.Configure();

            var app = builder.Build();
            // #if DEBUG
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // #endif
            app.Urls.Add("http://localhost:33001/");
            app.Urls.Add("https://localhost:33002/");
            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
