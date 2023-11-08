using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.Entities.Site;

namespace Walter.Core.Interfaces
{
    public interface IDashboardAccessService
    {
        Task<List<IpAddress>> GetAll();
        Task<IpAddress?> Get(int id);
        Task Create(IpAddress model);
        Task Update(IpAddress model);
        Task Delete(int id);
    }
}
