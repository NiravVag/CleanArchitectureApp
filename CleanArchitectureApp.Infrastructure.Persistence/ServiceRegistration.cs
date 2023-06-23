using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Application.Interfaces.Services;
using CleanArchitectureApp.Infrastructure.Persistence.Repositories;
using CleanArchitectureApp.Infrastructure.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MSSQLConnection");
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));


            #region Repositories

            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddScoped<IUserService, UserService>();

            #endregion Repositories
        }
    }
}
