using Exercicio3_API_Estacionamento.Entidades;
using Exercicio3_API_Estacionamento.Enumeradores;
using System;
using System.Collections.Generic;

namespace Exercicio3_API_Estacionamento.DTOs
{
    public class VeiculoDTO : Validator
    {
        public Guid? Id { get; set; }
        public string Placa { get; set; }
        public EtipoVeiculo TipoVeiculo { get; set; }


        public override void Validar()
        {
            Valido = true;

            Valido = false;
            if (Placa == null)
                Valido = false;
        }
    }
}
