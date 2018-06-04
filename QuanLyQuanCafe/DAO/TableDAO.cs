using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static int height = 80;
        public static int width = 80;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set => instance = value;
        }

        public TableDAO()
        {

        }

        public List<Table> LoadTableList()
        {
            List<Table> listTable = new List<Table>();

            DataTable data = DataProvider.Instance.ExcuteQuery("USP_TableFood");

            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                listTable.Add(table);
            }
            return listTable;
        }
    }
}
