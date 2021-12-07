using Exercicio3_API_Estacionamento.Entidades;
using System.Collections.Generic;

namespace Exercicio3_API_Estacionamento.Servicos
{
    public class VeiculoService
    {
        private readonly List<Veiculo> _veiculos;

        public VeiculoService()
        {
            _veiculos ??= new List<Veiculo>();
        }


        public Veiculo CadastrarVeiculo(Veiculo veiculo)
        {
            _veiculos.Add(veiculo);
            return veiculo;
        }
    }
}
