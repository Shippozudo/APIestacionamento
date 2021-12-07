namespace Exercicio3_API_Estacionamento.DTOs
{
    public class ReciboDTO
    {
        public ReciboDTO(int quantidadeHoras,
                         int valorTotal,
                         bool diaria,
                         bool lavagem)
        {
            QuantidadeHoras = quantidadeHoras;
            ValorTotal = valorTotal;
            Diaria = diaria;
            Lavagem = lavagem;
        }

        public int QuantidadeHoras { get; set; }
        public int ValorTotal { get; set; }
        public bool Diaria { get; set; }
        public bool Lavagem { get; set; }

       
    }
}
