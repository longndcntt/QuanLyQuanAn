﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Menu
    {
        private string foodName;
        private int count;
        private float price;
        private float totalPrice;

        public Menu(string food, int count, float price, float totalprice)
        {
            this.FoodName = food;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalprice;
        }

        public Menu(DataRow row)
        {
            this.FoodName = row["nameFood"].ToString();
            this.Count = (int)row["countFood"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }


        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
