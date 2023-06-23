namespace CleanArchitectureApp.ApiServices.Controllers.V1
{
    using CleanArchitectureApp.Application.Features.Users.Commands;
    using CleanArchitectureApp.Application.Features.Users.Queries;
    using CleanArchitectureApp.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    //[Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(GetAllUsersQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var getUserByIdQuery = new GetUserByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getUserByIdQuery));
        }

        [HttpPut("UpdateUserById")]
        public async Task<IActionResult> UpdateUserById(UpdateUserCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleteUserByIdQuery = new DeleteUserCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}
