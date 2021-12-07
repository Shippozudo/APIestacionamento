using System;
using System.Collections.Generic;

namespace Exercicio3_API_Estacionamento.Entidades
{
    public class Estacionamento : EntidadeBase
    {
        public Estacionamento(Guid id) : base(id)
        {
            Cliente = new List<Cliente>();
            Veiculo = new List<Veiculo>();
        }

        public List<Cliente> Cliente { get; set; }
        public List<Veiculo> Veiculo { get; set; }
    }
}
