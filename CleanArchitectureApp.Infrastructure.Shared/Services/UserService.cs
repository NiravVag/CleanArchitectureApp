using AutoMapper;
using CleanArchitectureApp.Application.DTOs.User;
using CleanArchitectureApp.Application.Features.Users.Commands;
using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Application.Interfaces.Services;
using CleanArchitectureApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Infrastructure.Shared.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoryAsync _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepositoryAsync userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public Task<User> AddUser(CreateUserCommand _object)
        {
            var addUser = _mapper.Map<User>(_object);
            return _userRepo.AddAsync(addUser);
        }

        public async Task DeleteUser(DeleteUserCommand _object)
        {
            var user = await _userRepo.FindByCondition(_object.Id);
            await _userRepo.DeleteAsync(user);
        }

        public async Task<User> EditUser(UpdateUserCommand _object)
        {
            if (_object == null) throw new ArgumentNullException(nameof(_object));

            var user = await _userRepo.FindByCondition(_object.Id);
            _mapper.Map(_object, user);
            return await _userRepo.UpdateAsync(user);
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            var getUserByID = await _userRepo.FindByCondition(id);
            return _mapper.Map<UserViewModel>(getUserByID);
        }

        public async Task<List<UserViewModel>> GetUserList()
        {
            var users = await _userRepo.GetAllAsync().ToListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }
    }
}
