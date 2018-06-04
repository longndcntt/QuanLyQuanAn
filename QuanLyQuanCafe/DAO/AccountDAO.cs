using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set => instance = value;
        }

        private AccountDAO()
        {

        }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_LoadAccount @username = N'" + userName + "' , @password = N'" + passWord + "'";

            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { userName, passWord });
            

            return data.Rows.Count > 0;
        }
    }
}
