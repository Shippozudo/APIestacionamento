using Exercicio3_API_Estacionamento.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio3_API_Estacionamento.Servicos
{
    public class ClienteService
    {
        private readonly List<Cliente> _cliente;
        private readonly VeiculoService _veiculoService;
        public ClienteService(VeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
            _cliente ??= new List<Cliente>();

        }

        public IEnumerable<Cliente> Get()
        {
            return _cliente;
        }

        public Cliente Get(Guid id)
        {
            return _cliente.Where(c => c.Id == id).SingleOrDefault();
        }

        public Cliente CadastrarCliente(Cliente cliente)
        {
            _cliente.Add(cliente);
            return cliente;
        }
    }
}
