using ProjectoFinanceiro.Domain.Entities;
using ProjectoFinanceiro.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Infrastructure.Contexts
{
    public interface IContext
    {
        public void CreateCliente(Cliente cliente);
        public List<Cliente> ReadCliente();
        public Cliente ReadCliente(int id);
        public void UpdateCliente(Cliente cliente); 
        public void DeleteCliente(int id);
    }
}
