using ProjectoFinanceiro.Domain.Entities;
using ProjectoFinanceiro.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectoFinanceiro.Testes.Helpers;

namespace ProjectoFinanceiro.Testes.Domain
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
            Cliente cliente = ClienteFactory.GetCliente();

            string message = $"Id: {cliente.ClienteId}, Nome: {cliente.Nome}";
            Console.WriteLine(message);
        }

        private void TestarDto()
        {
            ClienteDto cliente = ClienteDtoFactory.GetClienteDto();

            string message = $"Id: {cliente.ClienteId}, Nome: {cliente.Nome}";
            Console.WriteLine(message);
        }

        private void TestarConversaoEntidadeParaDto()
        {
            Cliente cliente = ClienteFactory.GetCliente();

            ClienteDto dto = cliente.ConverterParaDto();

            string message = $"Id: {dto.ClienteId}, Nome: {dto.Nome}";
            Console.WriteLine(message);
        }
        private void TestarConversaoDtoParaEntidade()
        {
            ClienteDto cliente = ClienteDtoFactory.GetClienteDto();

            Cliente entidade = cliente.ConverterParaEntidade();

            string message = $"Id: {entidade.ClienteId}, Nome: {entidade.Nome}";
            Console.WriteLine(message);
        }
    }
}
