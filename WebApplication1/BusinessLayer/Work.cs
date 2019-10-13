using DAL;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Work : IDisposable
    {
        bool disposed = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private WebApiDbEntities _db;

        public UserOperation Users { get; set; }

        void InitOperations()
        {
            this.Users = new UserOperation(_db, this);

        }
        public Work(WebApiDbEntities db)
        {
            _db = db;
            InitOperations();
        }

        public Work()
        {

            _db = new WebApiDbEntities();

            InitOperations();

        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();

                // Free any other managed objects here. 
                //
                _db.Dispose();
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }
    }
}
