using AutoMapper;
using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Application.Interfaces.Services;
using CleanArchitectureApp.Application.Wrappers;
using CleanArchitectureApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Users.Commands
{
    public partial class CreateUserCommand : IRequest<Response>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? Password { get; set; }
        public virtual string? Address { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response>
    {
        private readonly IUserService _userService;
        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {                       
            var userObject = await _userService.AddUser(request);
            return new Response("User Created Successfully");
        }
    }
}
