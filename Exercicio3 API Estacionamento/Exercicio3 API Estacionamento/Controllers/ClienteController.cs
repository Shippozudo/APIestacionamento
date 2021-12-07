using Exercicio3_API_Estacionamento.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio3_API_Estacionamento.Controllers
{
    [ApiController, Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }


    }

}
