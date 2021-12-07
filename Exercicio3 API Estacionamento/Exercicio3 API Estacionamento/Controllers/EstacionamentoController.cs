using Exercicio3_API_Estacionamento.DTOs;
using Exercicio3_API_Estacionamento.Entidades;
using Exercicio3_API_Estacionamento.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Exercicio3_API_Estacionamento.Controllers
{
    [ApiController, Route("[controller]")]
    public class EstacionamentoController : ControllerBase
    {

        private readonly EstacionamentoService _estacionamentoService;
        public IConfigurationSection ConfigurationPrecoCarro { get; set; }
        public IConfigurationSection ConfigurationPrecoMoto { get; set; }
        public EstacionamentoController(EstacionamentoService estacionamentoService, IConfiguration configuration)
        {
            _estacionamentoService = estacionamentoService;
            ConfigurationPrecoCarro = configuration.GetSection("PrecoCarro");
            ConfigurationPrecoMoto = configuration.GetSection("PrecoMoto");
        }








        [HttpGet, Route("ListaEstacionamento")] //Retorna Lista Clientes pelo id do Estacionamento
        public IActionResult Get()
        {

            return Ok(_estacionamentoService.Get());
        }

        [HttpGet, Route("{id}/{idCliente}/RetornaIdEstacionamento")] //retorna Cliente pelo ID do estacionamento e cliente

        public IActionResult Get(Guid id, Guid idCliente)
        {
            return Ok(_estacionamentoService.Get(id, idCliente));
        }


        [HttpPost, Route("CadastrarEstacionamento")]
        public IActionResult CadastrarEstacionamento(EstacionamentoDTO estacionamentoDTO)
        {
            estacionamentoDTO.Validar();
            if (!estacionamentoDTO.Valido)
                return BadRequest("Cadastro Invalido");

            var guid = Guid.NewGuid();
            var estacionamento = new Estacionamento(
                id: guid);

            return Created("", _estacionamentoService.CadastrarEstacionamento(estacionamento));

        }

        [HttpPost, Route("{id}/CadastrarCliente")]
        public IActionResult Cadastrar(Guid id, CadastrarClienteDTO cadastrarClienteDTO)
        {
            cadastrarClienteDTO.Validar();
            if (!cadastrarClienteDTO.Valido)
                return BadRequest("Cadastro Invalido");


            var idCliente = Guid.NewGuid();
            var idVeiculo = Guid.NewGuid();

            var cli = new Cliente(
                  id: idCliente,
                  nome: cadastrarClienteDTO.ClienteDTO.Nome,
                  horarioChegada: DateTime.Now,
                  diaria: cadastrarClienteDTO.ClienteDTO.Diaria,
                  lavagem: cadastrarClienteDTO.ClienteDTO.Lavagem,
                  veiculo: new Veiculo(
                  id: idVeiculo,
                  placa: cadastrarClienteDTO.VeiculoDTO.Placa,
                  tipoVeiculo: cadastrarClienteDTO.VeiculoDTO.TipoVeiculo)); ;

            return Created("", _estacionamentoService.Cadastrar(id, cli));
        }



        [HttpPost, Route("{id}/{idCliente} Calcular Valor Hora")]
        public IActionResult CalcularPreco(Guid id, Guid idCliente, ReciboDTO reciboDTO)
        {

            int preco = 2;
            var cliente = _estacionamentoService.Get(id, idCliente);

            

            cliente.HorarioSaida = DateTime.Now.AddMinutes(120);
            cliente.HorarioPermanencia = cliente.HorarioSaida - cliente.HorarioChegada;



            if (cliente.Veiculo.TipoVeiculo == Enumeradores.EtipoVeiculo.Carro)
            {
                if (cliente.Diaria == true)
                {
                    if (cliente.Lavagem == true)
                    {
                        preco = ConfigurationPrecoCarro.GetValue<int>("PrecoCarroLavacao");
                    }
                    else
                    {
                        preco = ConfigurationPrecoCarro.GetValue<int>("PrecoCarroDiaria");
                    }
                }
                else
                {
                    if (cliente.HorarioPermanencia <= TimeSpan.FromMinutes(15))
                    {
                        preco = ConfigurationPrecoCarro.GetValue<int>("PrecoCarro15min");
                    }
                    else if (cliente.HorarioPermanencia > TimeSpan.FromMinutes(15) && cliente.HorarioPermanencia <= TimeSpan.FromMinutes(60))
                    {
                        preco = ConfigurationPrecoCarro.GetValue<int>("PrecoCarroHora");

                    }
                    else if (cliente.HorarioPermanencia > TimeSpan.FromMinutes(60))
                    {

                        var i = cliente.HorarioPermanencia.Hours;
                        preco = i * ConfigurationPrecoCarro.GetValue<int>("PrecoCarroHora");

                    }

                }
            }
            else if (cliente.Veiculo.TipoVeiculo == Enumeradores.EtipoVeiculo.Moto)
            {
                if (cliente.Diaria == true)
                {
                    preco = ConfigurationPrecoMoto.GetValue<int>("PrecoMotoDiaria");
                }
                else
                {
                    if (cliente.HorarioPermanencia <= TimeSpan.FromMinutes(15))
                    {
                        preco = ConfigurationPrecoMoto.GetValue<int>("PrecoMoto15Min");
                    }

                    else if (cliente.HorarioPermanencia > TimeSpan.FromMinutes(15) && cliente.HorarioPermanencia <= TimeSpan.FromMinutes(60))
                    {
                        preco = ConfigurationPrecoMoto.GetValue<int>("PrecoMotoHora");

                    }
                    else if (cliente.HorarioPermanencia > TimeSpan.FromMinutes(60))
                    {

                        var i = cliente.HorarioPermanencia.Hours;
                        preco = i * ConfigurationPrecoMoto.GetValue<int>("PrecoMotoHora");

                    }
                }
            }

            var recibo = new ReciboDTO(
                quantidadeHoras: cliente.HorarioPermanencia.Hours,
                valorTotal:preco,
                diaria: cliente.Diaria,
                lavagem: cliente.Lavagem);

            return Created("", recibo);
            



        }






    }
}
