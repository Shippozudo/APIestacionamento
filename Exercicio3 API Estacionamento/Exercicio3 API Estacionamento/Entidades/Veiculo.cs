using Exercicio3_API_Estacionamento.Enumeradores;
using System;
using System.Collections.Generic;

namespace Exercicio3_API_Estacionamento.Entidades
{
    public class Veiculo : EntidadeBase
    {
        public Veiculo(Guid id,
                       string placa,
                       EtipoVeiculo tipoVeiculo) : base(id)
        {
            Placa = placa;
            TipoVeiculo = tipoVeiculo;

        }

        public string Placa { get; set; }
        public EtipoVeiculo TipoVeiculo { get; set; }

    }
}
