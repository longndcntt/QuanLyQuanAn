using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Table
    {
        public Table(int id, string name, string status)
        {
            this.Id = id;
            this.Name = name;
            this.StatusTable = status;
        }
        
        public Table(DataRow data)
        {
            this.Id = (int)data["id"];
            this.Name = data["name"].ToString();
            this.StatusTable = data["statusTable"].ToString();
        }

        private string name;

        private string statusTable;

        private int id;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string StatusTable { get => statusTable; set => statusTable = value; }
    }
}
