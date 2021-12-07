using Exercicio3_API_Estacionamento.Enumeradores;
using System;
using System.Collections.Generic;

namespace Exercicio3_API_Estacionamento.Entidades
{
    public class Cliente : EntidadeBase
    {
        public Cliente(Guid id,
                       string nome,
                       DateTime horarioChegada,
                       bool diaria,
                       bool lavagem,
                       Veiculo veiculo) : base(id)

        {
            Nome = nome;
            HorarioChegada = horarioChegada;
            Diaria = diaria;
            Lavagem = lavagem;
            Veiculo = veiculo;
        }

        public string Nome { get; set; }
        public DateTime HorarioChegada { get; set; }
        public DateTime HorarioSaida { get; set; }
        public TimeSpan HorarioPermanencia { get; set; }
        public bool Diaria { get; set; }
        public bool Lavagem { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
