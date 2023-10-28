using ProjectoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Testes.Helpers
{
    public static class ClienteFactory
    {
        public static  Cliente GetCliente()
        {
            Cliente cliente = new Cliente()
            {
                ClienteId = 1,
                Nome = "Boss Junior",
                Cpf = "87656783234"
            };
            return cliente;
        }

        public static Cliente GetNovoCliente()
        {
            Cliente cliente = new Cliente
            {
                ClienteId = 12,
                Nome = "Leopoldo Matsinhe",
                Cpf = "123567890"
            }; 
            return cliente;
        }
    }
}
