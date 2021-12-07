using System;

namespace Exercicio3_API_Estacionamento.Entidades
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
