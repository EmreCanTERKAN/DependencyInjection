using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationScoped _operationScoped1;
        private readonly IOperationScoped _operationScoped2;
        private readonly IOperationSingleton _operationSingleton;
        private readonly IOperationTransient _operationTransient;

        public OperationsController(IOperationScoped operationScoped1, IOperationScoped operationScoped2, IOperationSingleton operationSingleton, IOperationTransient operationTransient)
        {
            _operationScoped1 = operationScoped1;
            _operationScoped2 = operationScoped2;
            _operationSingleton = operationSingleton;
            _operationTransient = operationTransient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { 
                Transient = _operationTransient.OperationId,
                Scoped = _operationScoped1.OperationId,
                Singleton = _operationSingleton.OperationId
            });
        }

        [HttpGet("ScopedTest")]
        public IActionResult ScopedTest()
        {
            return Ok(new { Scoped1 = _operationScoped1, Scoped2 = _operationScoped2 });
        }
    }
}
