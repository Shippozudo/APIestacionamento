using System;

namespace Exercicio3_API_Estacionamento.DTOs
{
    public class CadastrarClienteDTO : Validator
    {
        public Guid? Id { get; set; }
        public ClienteDTO ClienteDTO { get; set; }
        public VeiculoDTO VeiculoDTO { get; set; }


        public override void Validar()
        {
            Valido = true;
            if (ClienteDTO == null)
                Valido = false;
            if (VeiculoDTO == null)
                Valido = false;
        }

    }
}
