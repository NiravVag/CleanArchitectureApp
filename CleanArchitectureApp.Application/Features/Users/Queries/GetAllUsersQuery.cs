using AutoMapper;
using CleanArchitectureApp.Application.DTOs.User;
using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Application.Interfaces.Services;
using CleanArchitectureApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Users.Queries
{
    public class GetAllUsersQuery : IRequest<Response<IEnumerable<UserViewModel>>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<IEnumerable<UserViewModel>>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersList = await _userService.GetUserList();
            return new Response<IEnumerable<UserViewModel>>(usersList);
        }
    }
}
