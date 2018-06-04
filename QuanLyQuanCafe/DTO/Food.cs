using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Food
    {
        private int iD;
        private string name;
        private int idCategory;
        private float price;

        public Food(int i, string n, int iC, float p)
        {
            this.ID = i;
            this.Name = n;
            this.IdCategory = iC;
            this.Price = p;

        }

        public Food(DataRow data)
        {
            this.ID = (int)data["ID"];
            this.IdCategory = (int)data["idCategory"];
            this.Name = data["nameFood"].ToString();
            this.Price = (float)Convert.ToDouble(data["price"].ToString());

        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}
