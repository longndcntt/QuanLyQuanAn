using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            private set => instance = value;
        }

        private CategoryDAO()
        {

        }

        public List<Category> LoadCategory()
        {
            List<Category> list = new List<Category>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM CATEGORY");

            foreach(DataRow item in data.Rows)
            {
                Category cate = new Category(item);
                list.Add(cate);
            }

            return list;
        }
    }
}
