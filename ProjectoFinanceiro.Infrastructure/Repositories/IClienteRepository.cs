﻿using ProjectoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinanceiro.Infrastructure.Repositories
{
    public interface IClienteRepository
    {
        public void Salvar(Cliente cliente);
        public void Actualizar(Cliente cliente);
        public void Excluir(int id);
        public Cliente Pesquisar(int id);
        public List<Cliente> Listar();
    }
}
