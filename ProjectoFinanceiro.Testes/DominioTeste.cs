using ProjectoFinanceiro.Domain.Entities;
using ProjectoFinanceiro.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Testes
{
    public class DominioTeste
    {
        public void Execute()
        {
            TestarEntidade();
            TestarDto();
            TestarConversaoEntidadeParaDto();
            TestarConversaoDtoParaEntidade();
        }

        private void TestarEntidade()
        {
            Cliente cliente = new Cliente()
            {
                ClienteId = 1,
                Nome = "Amancio Junior",
                Cpf = "12345678902124"
            };

            string message = $"Id: {cliente.ClienteId}, Nome: {cliente.Nome}";
            Console.WriteLine(message);
        }

        private void TestarDto()
        {
            ClienteDto cliente = new ClienteDto()
            {
                ClienteId = 1,
                Nome = "Amancio Junior",
                Cpf = "12345678902124"
            };

            string message = $"Id: {cliente.ClienteId}, Nome: {cliente.Nome}";
            Console.WriteLine(message);
        }

        private void TestarConversaoEntidadeParaDto()
        {
            Cliente cliente = new Cliente()
            {
                ClienteId = 1,
                Nome = "Amancio Junior",
                Cpf = "12345678902124"
            };
            ClienteDto dto = cliente.ConverterParaDto();

            string message = $"Id: {dto.ClienteId}, Nome: {dto.Nome}";
            Console.WriteLine(message);
        }
        private void TestarConversaoDtoParaEntidade()
        {
            ClienteDto cliente = new ClienteDto()
            {
                ClienteId = 1,
                Nome = "Amancio Junior",
                Cpf = "12345678902124"
            };
            Cliente entidade = cliente.ConverterParaEntidade();

            string message = $"Id: {entidade.ClienteId}, Nome: {entidade.Nome}";
            Console.WriteLine(message);
        }
    }
}
