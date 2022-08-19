using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalBusiness.Models;
using LocalBusiness.Repository;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace LocalBusiness.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class UsersController : ControllerBase
  {
    private readonly IJWTManagerRepository _jWTManager;

    public UsersController(IJWTManagerRepository jWTManager)
    {
      this._jWTManager = jWTManager;
    }

    [HttpGet]
    [Route("userlist")]
    public List<string> Get()
    {
      var users = new List<string>
      {
        "Zhibin Liang",
        "Carrie Xu",
        "Frank Tom"
      };

      return users;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("authenticate")]
    public IActionResult Authenticate(Users usersdata)
    {
      var token = _jWTManager.Authenticate(usersdata);

      if (token == null)
      {
        return Unauthorized();
      }

      return Ok(token);
    }
  }
}