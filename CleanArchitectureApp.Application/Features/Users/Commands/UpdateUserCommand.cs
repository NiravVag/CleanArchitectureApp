using AutoMapper;
using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Application.Interfaces.Services;
using CleanArchitectureApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.EditUser(request);

            return new Response("User Updated Successfully");
        }
    }
}
