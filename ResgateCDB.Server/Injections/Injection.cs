using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;


using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using Models.Interfaces;

using Services.Cache;
using Services.Interfaces;
using Services.Services;

namespace WebAPI.Injections
{

    [ExcludeFromCodeCoverage]
    public static class Injection
    {
        private const string _Autor = "https://github.com/hermessilva";
        private const string _MITLicence = "https://opensource.org/licenses/MIT";
        private static string[] _ValidXXMLDocs = ["controllers.xml", "models.xml", "services.xml", "toolkit.xml"];
        public static void Configure(this IServiceCollection pServices)
        {
            pServices.AddSingleton<IDataCache, DataCache>();
            pServices.AddScoped<ICalculoCdbService, CalculoCdbService>();
#if DEBUG
            SetSwaggerDocs(pServices);
#endif
        }

        private static void SetSwaggerDocs(IServiceCollection pServices)
        {
            pServices.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", CreteOpenApiInfo());
                opt.EnableAnnotations();
                var files = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly);
                foreach (var file in files.Where(ff => _ValidXXMLDocs.Any(f => Path.GetFileName(ff).ToLower() == f)))
                    opt.IncludeXmlComments(file);
            });
        }

        private static OpenApiInfo CreteOpenApiInfo()
        {
            return new OpenApiInfo
            {
                Title = "Cáculo de CDB API",
                Version = "v1",
                Description = "Este Projeto é uma apresentação de uma visão da Clean Architecture, criado por Hermes J Silva.",
                Contact = new OpenApiContact
                {
                    Name = "Hermes J Silva",
                    Email = "hxpelo@gmail.com",
                    Url = new Uri(_Autor)
                },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri(_MITLicence)
                },
                TermsOfService = new Uri(_MITLicence)
            };
        }
    }
}
