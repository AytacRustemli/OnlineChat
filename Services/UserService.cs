using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace Services
{
    public class UserService
    {
        private readonly ChatDbContext _context;

        public UserService(ChatDbContext context)
        {
            _context = context;
        }

        public List<Users> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
