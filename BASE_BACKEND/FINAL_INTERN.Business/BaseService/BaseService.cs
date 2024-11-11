
using FINAL_INTERN.Data.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_INTERN.Bussiness.BaseService
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<T> GetByID(int id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }
    }
}
