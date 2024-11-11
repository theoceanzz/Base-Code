using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_INTERN.Bussiness.BaseService
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetByID(int id);
    }
}
