using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set => instance = value;
        }

        private MenuDAO()
        {

        }

        public List<Menu>  GetListMenuByTableId (int id)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = "SELECT TF.nameFood, bi.countFood, TF.price , BI.countFood * TF.price AS totalPrice  FROM BILL B, dbo.BILLINFO BI, dbo.FOOD TF, dbo.TABLEFOOD t WHERE B.ID = BI.idBill AND TF.ID = BI.idFood AND B.idTable = " + id + " AND B.statusBill = 0 AND t.ID = B.idTable    ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            
            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }

         public DataTable GetListCategory()
        {
            string query = "Select name FROM CATEGORY";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

    }

}
