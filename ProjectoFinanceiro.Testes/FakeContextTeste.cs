using ProjectoFinanceiro.Domain.Entities;
using ProjectoFinanceiro.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Testes
{
    public class FakeContextTeste
    {
        private readonly IContext _context;

        public FakeContextTeste()
        {
            _context = new FakeContext();
        }

        public void Execute()
        {
            TestarListagem();
            TestarInclusao();
        }
        private void TestarListagem()
        {
            List<Cliente> clientes = _context.ReadCliente();
            foreach (Cliente item in clientes)
            {
                Console.WriteLine($"Id:{item.ClienteId}, Nome: { item.Nome}");
            }
        }
        private void TestarInclusao()
        {
            Cliente cliente = new Cliente
            {
                ClienteId = 12,
                Nome = "Leopoldo Matsinhe",
                Cpf = "123567890"
            };
            _context.CreateCliente( cliente );

            Cliente result = _context.ReadCliente(cliente.ClienteId);


        }
    }
}
