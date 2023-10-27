using ProjectoFinanceiro.Domain.Entities;
using ProjectoFinanceiro.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Infrastructure.Contexts
{
    public class FakeContext : IContext
    {
        private List<Cliente> _clientes;

        public FakeContext() 
        {
            LoadData();
        }

        public void CreateCliente(Cliente cliente)
        {
           _clientes.Add(cliente);
        }

        public List<Cliente> ReadCliente()
        {
            return _clientes
                .OrderBy(p => p.ClienteId)
                .ToList();
        }

        public Cliente ReadCliente(int id)
        {
           Cliente result = _clientes
                .FirstOrDefault(p => p.ClienteId.Equals(id));
            return result;
        }

        public void UpdateCliente(Cliente cliente)
        {
            Cliente objPesquisa = ReadCliente(cliente.ClienteId);
            _clientes.Remove(objPesquisa);

            objPesquisa = new Cliente
            {
                ClienteId = cliente.ClienteId,
                Nome = !string.IsNullOrEmpty(cliente.Nome) ? cliente.Nome : objPesquisa.Nome,
                Cpf = !string.IsNullOrEmpty (cliente.Cpf) ? cliente.Cpf : objPesquisa.Cpf
            };
            _clientes.Add(objPesquisa ); 
        }

        public void DeleteCliente(int id)
        {
            Cliente cliente = ReadCliente(id);
            if(cliente != null)
            {
                _clientes.Remove (cliente);
            }
        }

        private void LoadData()
        {
            _clientes = new List<Cliente>();

            Cliente cliente = new Cliente
            {
                ClienteId = 1,
                Nome = "Team Bananas",
                Cpf = "345678987654"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 2,
                Nome = "Edipson Banana",
                Cpf = "98765435678"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 3,
                Nome = "Leopoldo Banana",
                Cpf = "98765789012"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 4,
                Nome = "Edwin Banana",
                Cpf = "1234678945"
            };
            _clientes.Add(cliente);
        }
    }
}
