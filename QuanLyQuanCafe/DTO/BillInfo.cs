using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfo
    {
        private int id;
        private int idBill;
        private int idFood;
        private int countFood;

        public BillInfo(int id, int idBill, int idF, int cF)
        {
            this.Id = id;
            this.IdBill = idBill;
            this.IdFood = idF;
            this.CountFood = cF;

        }

        public BillInfo(DataRow data)
        {
            this.Id = (int)data["ID"];
            this.IdBill = (int)data["idBill"];
            this.IdFood = (int)data["idFood"];
            this.CountFood = (int)data["countFood"];

        }

        public int CountFood { get => countFood; set => countFood = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int Id { get => id; set => id = value; }
    }
}
