using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalBusiness.Models;

namespace LocalBusiness.Repository
{
   public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users user); 
    }
   
}