// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using ProjectoFinanceiro.Testes.Extensions;
using ProjectoFinanceiro.Testes.Principal;
using System;
class program
{
    static void Main(string[] args)
    {
        try
        {
            var serviceCollection = ConfigureServices();
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            var eventService = serviceProvider.GetRequiredService<AppTestePrincipal>();
            eventService.Execute();
        }
        catch (Exception ex)
        {
             throw ex;
        }
    }
    static IServiceCollection ConfigureServices()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.RegisterDependencies();
        serviceCollection.AddDependencies();
        return serviceCollection;
    }
  
}


