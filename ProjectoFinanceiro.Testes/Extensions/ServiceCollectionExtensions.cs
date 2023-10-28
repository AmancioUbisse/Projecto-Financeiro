using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectoFinanceiro.Infrastructure.Repositories;
using ProjectoFinanceiro.Services.Service;
using ProjectoFinanceiro.Testes.Principal;
using ProjectoFinanceiro.Testes.Repositories;
using ProjectoFinanceiro.Testes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Testes.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            IConfiguration configuration = GetConfiguration();
            services.AddSingleton<IConfiguration>(configuration);
            return services;
        }

        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppTestePrincipal>();
            // Adicionar serviços
            //Repositorios
            services.AddScoped<IClienteRepository, ClienteRepository>();

            //Servicos
            services.AddScoped<ClienteService>();

            //Testes
            services.AddScoped<RepositorioTeste>();
            services.AddScoped<ServicoTeste>();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddEnvironmentVariables();

            var configuration = builder.Build();    
            return configuration;
        }
    }
}
