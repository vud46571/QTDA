using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Areas.User.Model.DAO
{
    public class AccountDAO
    {
        private static Models.DoanNCEntities db = new Models.DoanNCEntities();

        public AccountDAO()
        {
        }
        public static bool checkLogin(string Users, string Passwords)
        {
            // Hash password before check

            int num = db.ThanhViens.Count(x => x.Username == Users && x.Password == Passwords);
            return num == 1;
        }
    }
}