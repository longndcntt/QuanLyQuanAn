using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        private int iD;
        private int iDTable;
        private DateTime checkIn;
        private DateTime? checkOut;
        private int statusBill;

        public Bill(int id, int idT, DateTime cin , DateTime? cout, int s)
        {
            this.ID = id;
            this.IDTable = idT;
            this.CheckIn = cin;
            this.CheckOut = cout;
            this.StatusBill = s;
        }

        public Bill(DataRow data)
        {
            this.ID = (int)data["ID"];
            this.IDTable = (int)data["idTable"];
            this.CheckIn = (DateTime)data["checkIn"];

            var checkOutTemp = data["checkPut"];
            if(checkOutTemp.ToString() != "")
                this.CheckOut = (DateTime?)data["checkPut"];

            this.StatusBill = (int)data["statusBill"];
        }


        public int ID { get => iD; set => iD = value; }
        public int IDTable { get => iDTable; set => iDTable = value; }
        public DateTime CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime? CheckOut { get => checkOut; set => checkOut = value; }
        public int StatusBill { get => statusBill; set => statusBill = value; }
    }
}
