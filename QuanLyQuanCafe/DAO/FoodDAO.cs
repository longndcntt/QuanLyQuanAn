using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set => instance = value;
        }

        private FoodDAO()
        {

        }

        public List<Food> LoadFoodList(int id)
        {
            List<Food> list = new List<Food>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM  dbo.FOOD where idCategory = " + id);
            foreach(DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
    }
}
