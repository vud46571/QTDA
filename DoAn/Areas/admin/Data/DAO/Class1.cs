using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAn.Models;


namespace DoAn.Areas.admin.Data.DAO
{
    public class Class1
    {
        private static Models.DoanNCEntities db = new Models.DoanNCEntities();
        public Class1()
        {
        }
        public static int CheckLogin(String Username, String Passwords)
        {
            int num = db.Admins.Count(x => x.Username == Username && x.Password == Passwords);
            if (num > 0) { return 1; }
            return 0;
        }
    }
}