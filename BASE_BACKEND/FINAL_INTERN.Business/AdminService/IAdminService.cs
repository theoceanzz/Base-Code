using FINAL_INTERN.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_INTERN.Business.AdminService
{
    public interface IAdminService
    {
        Task<IEnumerable<Account>> GetAllUsersAsync();
        Task<Account> GetUserByIdAsync(int id);
        Task<Account> AddUserAsync(Account user);
        Task<Account> UpdateUserAsync(Account user);
        Task<Account> DeleteUserAsync(int id);
        Task<IEnumerable<Account>> GetUserByEmail(string email);
        
    }
}
