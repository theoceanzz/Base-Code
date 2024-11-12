using FINAL_INTERN.Business.AdminService;
using FINAL_INTERN.Models.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FINAL_INTERN.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController: ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService=adminService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAccount()
        {
            var accounts = await _adminService.GetAllUsersAsync();
            return Ok(accounts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountByID(int id)
        {
            var accounts= await _adminService.GetUserByIdAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(accounts);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(Account account)
        {
            var createAccount = await _adminService.AddUserAsync(account);
            return CreatedAtAction(nameof(AddAccount), account, createAccount);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var deleteEntity = await _adminService.DeleteUserAsync(id);
            return deleteEntity==null ? NotFound() : Ok(deleteEntity);
        }
        [HttpPatch("accounts/{id}/cancel")]
        public async Task<IActionResult> CancelAccount(int id)
        {
            var appointment = await _adminService.GetUserByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            appointment.IsActive = (bool)appointment.IsActive ? false : true;
            var updatedAppointment = await _adminService.UpdateUserAsync(appointment);

            return Ok(updatedAppointment);
        }
        [HttpPatch("accounts/{id}/grant-permission")]
        public async Task<IActionResult> GrantPermission(int id, int newRole)
        {
            // Fetch the account by ID
            var account = await _adminService.GetUserByIdAsync(id);

            // Check if the account exists
            if (account == null)
            {
                return NotFound();
            }

            // Update the role or permission level (assuming the account has a 'Role' or 'PermissionLevel' property)
            account.RoleId = newRole;

            // Save the updated account
            var updatedAccount = await _adminService.UpdateUserAsync(account);

            return Ok(updatedAccount);
        }

    }
}
