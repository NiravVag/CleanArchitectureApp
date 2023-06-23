using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Infrastructure.Persistence
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(ApplicationDBContext context) : base(context)
        { }

    }
}
