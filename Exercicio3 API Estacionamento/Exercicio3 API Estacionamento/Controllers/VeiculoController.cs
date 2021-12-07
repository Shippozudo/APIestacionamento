using Exercicio3_API_Estacionamento.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio3_API_Estacionamento.Controllers
{

    [ApiController, Route("[controller]")]
    public class VeiculoController : ControllerBase
    {

        private readonly VeiculoService _veiculoService;
        public VeiculoController(VeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }
    }
}
