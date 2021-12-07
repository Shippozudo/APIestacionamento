using Exercicio3_API_Estacionamento.Entidades;
using Exercicio3_API_Estacionamento.Enumeradores;
using System;
using System.Collections.Generic;

namespace Exercicio3_API_Estacionamento.DTOs
{
    public class ClienteDTO : Validator
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public DateTime HorarioChegada { get; set; }
        public DateTime HorarioSaida { get; set; }
        public TimeSpan HorarioPermanencia { get; set; }
        public bool Diaria { get; set; }
        public bool Lavagem { get; set; } 
        public Veiculo Veiculo { get; set; }

        public override void Validar()
        {
            Valido = true;
            if (Nome == null)
                Valido = false;
            if (Veiculo == null)
                Valido = false;
        }
    }
}
