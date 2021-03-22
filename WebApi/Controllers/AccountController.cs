using Api.CrossCuting.DTO;
using Api.Service.ApplicationService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly AccountApplicationService _applicationService;

        public AccountController(AccountApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDto account)
        {
            return Ok(await _applicationService.CreateNewAccount(account.Name));
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAccount([FromQuery] string name, [FromQuery] int id)
        {
            await _applicationService.UpdateUserNameAccount(id, name);
            return Ok();
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteAccount([FromQuery] int id)
        {
            await _applicationService.DeleteAccountById(id);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAccount([FromQuery] int id)
        {
            return Ok(await _applicationService.GetAccountById(id));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok(await _applicationService.GetAllAccounts());
        }
    }
}
