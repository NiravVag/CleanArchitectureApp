using CleanArchitectureApp.Application.DTOs.User;
using CleanArchitectureApp.Application.Features.Users.Commands;
using CleanArchitectureApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<User> AddUser(CreateUserCommand _object);

        public Task<User> EditUser(UpdateUserCommand _object);

        public Task <List<UserViewModel>> GetUserList();

        public Task<UserViewModel> GetUserById(int id);

        public Task DeleteUser(DeleteUserCommand _object);
    }
}
