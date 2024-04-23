using Microsoft.AspNetCore.Mvc;
using Petfolio.API.UseCases.Pets.GetAll;
using Petfolio.API.UseCases.Pets.Register;
using Petfolio.API.UseCases.Pets.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

#region NOTAS
/*
 Notas: 
Regra de negócio = UseCase
Princípio da responsabilidade única (SOLID)
S = Single responsability
Que está ligado ao fato de que cada classe será responsável apenas por 1 regra de negócio.
 */
#endregion

namespace Petfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestPetJson request)
        {
            var response = new RegisterPetUseCase().Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Update ([FromRoute] int id, [FromBody] RequestPetJson request)
        {
            var useCase = new UpdatePetUseCase();
            
            useCase.Execute(id, request);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllPetsUseCase();
            var response = useCase.Execute();
            if(response.Pets.Any()) 
            {
                return Ok(response);
            } else
            {
            return NoContent();
            }
        }
    }
} 
