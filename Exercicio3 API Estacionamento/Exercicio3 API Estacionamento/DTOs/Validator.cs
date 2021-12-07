namespace Exercicio3_API_Estacionamento.DTOs
{
    public abstract class Validator
    {
        public bool Valido { get; protected set; }
        public abstract void Validar();
    }
}
