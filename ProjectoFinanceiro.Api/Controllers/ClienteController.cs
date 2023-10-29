using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectoFinanceiro.Domain.Dtos;
using ProjectoFinanceiro.Domain.Entities;
using ProjectoFinanceiro.Services.Service;

namespace ProjectoFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public List<ClienteDto> Listar()
        {
            try
            {
                List<Cliente> clientes = _clienteService.Listar();
                List<ClienteDto> clientesDto = clientes != null ? Cliente.ConverterParaDto(clientes) : null;
                return clientesDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("{id}")]
        public ClienteDto Pesquisar(int id)
        {
            try
            {
                Cliente cliente = _clienteService.Pesquisar(id);
                ClienteDto dto = cliente != null ? cliente.ConverterParaDto() : null;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public string Excluir(int id)
        {
            try
            {
                _clienteService.Excluir(id);
                return $"Cliente excluido com sucesso, Id: {id}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


            [HttpPost]
            public string Cadastrar([Bind("nome, cpf")] ClienteDto clienteDto)
            {
                try
                {
                    Cliente cliente = clienteDto.ConverterParaEntidade();
                    _clienteService.Salvar(cliente);
                    return $"Cliente {cliente.Nome} cadastrado com sucesso, Id: {cliente.ClienteId}";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            [HttpPut]
            public string Actualizar([FromBody] ClienteDto clienteDto)
            {
                try
                {
                    Cliente cliente = clienteDto.ConverterParaEntidade();
                    _clienteService.Actualizar(cliente);
                    return $"Cliente {cliente.Nome} actualizado com sucesso, Id: {cliente.ClienteId}";
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }

