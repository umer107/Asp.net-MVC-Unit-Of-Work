using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Infrastructure
{
    public class DataOperations
    {
        // this is default branch
        public Work Work { get; set; }

        protected WebApiDbEntities db { get; set; }

        public DataOperations(WebApiDbEntities dbContext, Work work)
        {
            db = dbContext;
            this.Work = work;
        }

        //public void Dispose()
        //{
        //    db.Dispose();
        //}


    }
}
