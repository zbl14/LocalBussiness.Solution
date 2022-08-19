using System;
using System.Collections.Generic;
using System.Linq;
using LocalBusiness.Models;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace LocalBusiness.Repository
{
  public class JWTManagerRepository : IJWTManagerRepository
  {
    Dictionary<string, string> UsersRecords = new Dictionary<string, string>
    {
      { "user1","password1" },
      { "user2","password2" },
      { "user3","password3" },
    };

    private readonly IConfiguration _iconfiguration;
    public JWTManagerRepository(IConfiguration iconfiguration)
    {
      this._iconfiguration = iconfiguration;
    }
    public Tokens Authenticate(Users user)
    {
      if (!UsersRecords.Any(x => x.Key == user.Name && x.Value == user.Password)) {
        return null;
      }

      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.Name)                    
        }),
        Expires = DateTime.UtcNow.AddMinutes(10),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return new Tokens { Token = tokenHandler.WriteToken(token) };
    }
  }
}