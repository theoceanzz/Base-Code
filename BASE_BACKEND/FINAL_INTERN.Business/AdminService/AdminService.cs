using FINAL_INTERN.Data.BaseRepository;
using FINAL_INTERN.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_INTERN.Business.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IBaseRepository<Account> baseRepository;
        public AdminService(IBaseRepository<Account> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public async Task<Account> AddUserAsync(Account user)
        {
            await baseRepository.AddAsync(user);
            return user;    
        }

        public async Task<Account> DeleteUserAsync(int id)
        {
            var entiry = await baseRepository.GetByIdAsync(id);
            if (entiry != null) { 
            await baseRepository.DeleteAsync(id); 
                
            }
            return entiry;
        }

        public async Task<IEnumerable<Account>> GetAllUsersAsync()
        {
            return await baseRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Account>> GetUserByEmail(string email)
        {
            var entities = await baseRepository.SearchByNameAsync(email);
            return (IEnumerable<Account>)entities;
            
        }

        public async Task<Account?> GetUserByIdAsync(int id)
        {
           var entities = await baseRepository.GetByIdAsync(id);
            if (entities != null)
            {
                return entities;
            }
            return null;
        }

        public async Task<Account> UpdateUserAsync(Account user)
        {
           
            if (user != null)
            {
                await baseRepository.UpdateAsync(user);
            }
            return user;
        }
    }
}
