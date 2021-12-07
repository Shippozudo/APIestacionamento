using Exercicio3_API_Estacionamento.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio3_API_Estacionamento.Servicos
{
    public class EstacionamentoService
    {
        private readonly List<Estacionamento> _estacionamento;
        private readonly ClienteService _clienteService;
        private readonly VeiculoService _veiculoService;


        public EstacionamentoService(ClienteService clienteService, VeiculoService veiculoService)
        {
            _clienteService = clienteService;
            _veiculoService = veiculoService;
            _estacionamento ??= new List<Estacionamento>();

        }



        public IEnumerable<Estacionamento> Get() // Retorna Lista Clientes pelo id do Estacionamento
        {
            return _estacionamento;

        }

        public Cliente Get(Guid id, Guid idCliente) //retorna Cliente pelo ID do estacionamento e cliente
        {
            var est = _estacionamento.Where(e => e.Id == id).SingleOrDefault();
            var idCli = est.Cliente.Where(c => c.Id == idCliente).SingleOrDefault();

            return idCli;

        }



        public Estacionamento CadastrarEstacionamento(Estacionamento estacionamento)
        {
            _estacionamento.Add(estacionamento);
            return estacionamento;
        }


        public Estacionamento Cadastrar(Guid estacionamentoId, Cliente cliente)
        {
            var cli = _clienteService.CadastrarCliente(cliente);
            var vei = _veiculoService.CadastrarVeiculo(cliente.Veiculo);

            var estacionamento = _estacionamento.Where(e => e.Id == estacionamentoId).SingleOrDefault();

            estacionamento.Cliente.Add(cli);
            estacionamento.Veiculo.Add(vei);


            return estacionamento;


        }

        public Cliente CalcularPreco(Guid id, Guid idCliente)
        {

            var est = _estacionamento.Where(e => e.Id == id).SingleOrDefault();
            var idCli = est.Cliente.Where(c => c.Id == idCliente).SingleOrDefault();

            return idCli;


        }
    }
}
