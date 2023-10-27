using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Testes
{
    public class AppTestePrincipal
    {
        private readonly RepositorioTeste _repositorioTeste;
        private readonly ServicoTeste _servicoTeste; 
        public AppTestePrincipal(RepositorioTeste repositorioTeste, ServicoTeste servicoTeste) 
        {
            _repositorioTeste = repositorioTeste;
            _servicoTeste = servicoTeste;
        }

        public void Execute()
        {
            //ValidarCamadaDominio();
            //ValidarCamadaEstrutura_Context();
            //ValidarCamadaRepositorio();
            ValidarCamadaServico();
        }

        private static void ValidarCamadaEstrutura_Context()
        {
            FakeContextTeste teste = new FakeContextTeste();
            teste.Execute();
        }

        private static void ValidarCamadaDominio()
        {
            DominioTeste teste = new DominioTeste();
            teste.Execute();
        }

        private void ValidarCamadaRepositorio()
        {
            _repositorioTeste.Execute();
        }

        private void ValidarCamadaServico()
        {
            _servicoTeste.Execute();
        }

    }
}
