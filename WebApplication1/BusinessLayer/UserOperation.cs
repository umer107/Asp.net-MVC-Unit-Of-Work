using BusinessLayer.Infrastructure;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserOperation : DataOperations
    {
        public UserOperation(WebApiDbEntities db, Work work)
            : base(db, work)
        {

        }


        public List<User> GetUsers()
        {
            return Read<User>().ToList();
        }
    }
}
