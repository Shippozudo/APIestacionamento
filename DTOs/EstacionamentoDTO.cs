using Exercicio3_API_Estacionamento.Entidades;
using System;

namespace Exercicio3_API_Estacionamento.DTOs
{
    public class EstacionamentoDTO : Validator
    {
        public Guid? Id { get; set; }
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }

        public override void Validar()
        {
            Valido = true;
            if (Cliente == null)
                Valido = false;
            if (Veiculo == null)
                Valido = false;
        }
    }
}
