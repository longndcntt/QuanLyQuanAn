using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class BillDAO
    {
        private static BillDAO instance;

        internal static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value;
        }

        private BillDAO()
        {

        }
        // Nếu bill tồn tại : bill.ID >< -1
        public int GetUnCheckBillByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM BILL WHERE idTable = " + id + " AND statusBill = 0 ");

             if (data.Rows.Count > 0)
             {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
             }
            
            return -1;
        }

        public void InsertBill(int idTable)
        {
            DataProvider.Instance.ExcuteNonQuery("Exec USP_InsertBill @idTable" , new object[] {idTable});
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar(" SELECT MAX(ID) FROM dbo.BILL ");
            }
            catch
            {
                return 1;
            }
            
        }

        public void CheckOut(int idBill)
        {
            DataProvider.Instance.ExcuteNonQuery("UPDATE dbo.BILL SET statusBill = 1 WHERE ID = " + idBill);
        }
    }
}
