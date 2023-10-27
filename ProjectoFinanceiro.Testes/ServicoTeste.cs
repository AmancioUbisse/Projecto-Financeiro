using ProjectoFinanceiro.Domain.Entities;
using ProjectoFinanceiro.Infrastructure.Repositories;
using ProjectoFinanceiro.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Testes
{
    public class ServicoTeste
    {
        private readonly ClienteService _clienteService;

        public ServicoTeste(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        
        public void Execute()
        {
            try
            {
                ValidarListagemClientes();
                ValidarPesquisaCliente();
                ValidarCadastroCliente();
                ValidarActualizacaoCliente();
                ValidarExclusaocaoCliente();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ValidarListagemClientes()
        {
            Console.WriteLine("Teste Camada de Servicos: ValidarListagemClientes");
            List<Cliente> clientes = _clienteService.Listar();
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"Id: {cliente.ClienteId}, Nome:{cliente.Nome}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            Console.WriteLine("Teste Camada de Servicos: ValidarPesquisaCliente");
            int id = 1;
            Cliente cliente = _clienteService.Pesquisar(id);
            Console.WriteLine($"Id:{cliente.ClienteId}, Nome:{cliente.Nome}");
        }
        private void ValidarCadastroCliente()
        {
            Console.WriteLine("Teste Camada de Servicos: ValidarCadastroCliente");
            int id = 55;

            Cliente cliente = new Cliente
            {
                ClienteId = 55,
                Nome = "Super Programador"
            };
            _clienteService.Salvar(cliente);

            Cliente objPesquisa = _clienteService.Pesquisar(id);
            Console.WriteLine($"Id: {objPesquisa.ClienteId}, Nome:{objPesquisa.Nome}");
        }

        private void ValidarActualizacaoCliente()
        {
            Console.WriteLine("Teste Camada de Servicos: ValidarActualizacaoCliente");

            int id = 1;
            Cliente cliente = _clienteService.Pesquisar(id);
            cliente.Nome = "Jose Novela";
            _clienteService.Actualizar(cliente);

            Cliente objPesquisa = _clienteService.Pesquisar(id);
            Console.WriteLine($"Id: {objPesquisa.ClienteId}, Nome:{objPesquisa.Nome}");
        }

        private void ValidarExclusaocaoCliente()
        {
            Console.WriteLine("Teste Camada de Servicos: ValidarExclusaocaoCliente");

            int id = 1;
            _clienteService.Excluir(id);

            Cliente cliente = _clienteService.Pesquisar(id);
        }
    }
}