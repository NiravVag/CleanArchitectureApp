using NHibernate.Mapping.ByCode.Conformist;
using CleanArchitectureApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public partial class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("Users");
            Lazy(true);
            Id(x => x.Id);
            Property(x => x.FirstName, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.LastName, map => map.Length(50));
            Property(x => x.Email, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.Password, map => map.NotNullable(true));
            Property(x => x.Address, map => map.Length(50));
        }
    }
}
