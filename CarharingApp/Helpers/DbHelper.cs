using CarharingApp;
using System;

namespace CarsharingApp.Helpers
{
    public static class DbHelper
    {
        private static CarsharingDBEntities _context;

        public static CarsharingDBEntities GetContext()
        {
            if (_context == null)
            {
                _context = new CarsharingDBEntities();
            }
            return _context;
        }
    }
}