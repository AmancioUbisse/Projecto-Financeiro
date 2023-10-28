using ProjectoFinanceiro.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Testes.Helpers
{
    public static class ClienteDtoFactory
    {
        public static ClienteDto GetClienteDto()
        {
            ClienteDto cliente = new ClienteDto()
            {
                ClienteId = 1,
                Nome = "Amancio Junior",
                Cpf = "12345678902124"
            };
            return cliente;
        }
    }
}
