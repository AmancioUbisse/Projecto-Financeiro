using ProjectoFinanceiro.Domain.Entities;
using ProjectoFinanceiro.Domain.Enums;
using ProjectoFinanceiro.Domain.Setup;
using ProjectoFinanceiro.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IContext _context;
        public ClienteRepository() 
        {
            if(ConfiguracoesApp.SELECTED_DATABASE.Equals(DatabaseType.Fake))
            {
                _context = new FakeContext();
            }
        }

        public void Actualizar(Cliente cliente)
        {
            _context.UpdateCliente(cliente);
        }

        public void Excluir(int id)
        {
            _context.DeleteCliente(id);
        }

        public List<Cliente> Listar()
        {
            return _context.ReadCliente();
        }

        public Cliente Pesquisar(int id)
        {
            return _context.ReadCliente(id);
        }

        public void Salvar(Cliente cliente)
        {
            _context.CreateCliente(cliente);
        }
    }
}
