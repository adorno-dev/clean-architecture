using CleanArchitecture.Application.UseCases.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            // var validator = new CreateUserValidator();
            // var validationResult = await validator.ValidateAsync(request);

            // if (! validationResult.IsValid)
            //     return BadRequest(validationResult.Errors);

            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}