using ProjectoFinanceiro.Domain.Entities;
using ProjectoFinanceiro.Infrastructure.Repositories;
using ProjectoFinanceiro.Testes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Testes.Repositories
{
    public class RepositorioTeste
    {
        private readonly IClienteRepository _clienteRepository;

        public RepositorioTeste(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
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
            List<Cliente> clientes = _clienteRepository.Listar();
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"Id: {cliente.ClienteId}, Nome:{cliente.Nome}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            int id = 1;
            Cliente cliente = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"Id:{cliente.ClienteId}, Nome:{cliente.Nome}");
        }
        private void ValidarCadastroCliente()
        {

            Cliente cliente =  ClienteFactory.GetNovoCliente();
            int id = cliente.ClienteId;

            _clienteRepository.Salvar(cliente);

            Cliente objPesquisa = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"Id: {objPesquisa.ClienteId}, Nome:{objPesquisa.Nome}");
        }

        private void ValidarActualizacaoCliente()
        {
            int id = 1;
            Cliente cliente = _clienteRepository.Pesquisar(id);
            cliente.Nome = "Jose Novela";
            _clienteRepository.Actualizar(cliente);

            Cliente objPesquisa = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"Id: {objPesquisa.ClienteId}, Nome:{objPesquisa.Nome}");
        }

        private void ValidarExclusaocaoCliente()
        {
            int id = 1;
            _clienteRepository.Excluir(id);

            Cliente cliente = _clienteRepository.Pesquisar(id);
        }
    }
}
