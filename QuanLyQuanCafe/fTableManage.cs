using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fTableManage : Form
    {
        public fTableManage()
        {
            InitializeComponent();
            LoadTable();
            LoadComboBoxCategory();
        }

        private void LoadTable()
        {
            flwListTable.Controls.Clear();
            List<Table> table = TableDAO.Instance.LoadTableList();
            foreach(Table item in table)
            {
                Button btn = new Button()
                {
                    Height = TableDAO.height,
                    Width = TableDAO.width

                };
                if ( item.StatusTable.Equals("Có người"))
                {
                    btn.BackColor = Color.HotPink;
                }
                else
                {
                    btn.BackColor = Color.DimGray;
                }
                btn.Text = item.Name + Environment.NewLine + item.StatusTable;
                btn.Click += Btn_Click;
                btn.Tag = item;

                flwListTable.Controls.Add(btn);
            }
        }



        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).Id;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
            
        }

        private void ShowBill(int tableID)
        {
            lsvBill.Items.Clear();
            List<DTO.Menu> listMenu = MenuDAO.Instance.GetListMenuByTableId(tableID);
            float totalPrice = 0;
            foreach(DTO.Menu item in listMenu)
            {
                ListViewItem lvi = new ListViewItem(item.FoodName.ToString());
                lvi.SubItems.Add(item.Count.ToString());
                lvi.SubItems.Add(item.Price.ToString());
                lvi.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lvi);
            }
            CultureInfo culture = new CultureInfo("vi");

            txbCheckOut.Text = totalPrice.ToString("c", culture);

        }

        private void LoadComboBoxCategory()
        {
            List<Category> list = CategoryDAO.Instance.LoadCategory();
            cboCategory.DataSource = list;
            cboCategory.DisplayMember = "name";
        }

        private void LoadFoodList(int id)
        {
            List<Food> list = FoodDAO.Instance.LoadFoodList(id);
            cboFood.DataSource = list;
            cboFood.DisplayMember = "Name";
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile accountProfile = new fAccountProfile();

            accountProfile.ShowDialog();

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin admin = new fAdmin();
            admin.ShowDialog();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            LoadFoodList(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.Id);

            int idFood = (cboFood.SelectedItem as Food).ID;

            int count = (int)nmFoodCount.Value;
            if(idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.Id);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idFood, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);

            }
            ShowBill(table.Id);
            LoadTable();

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.Id);
            
            if(idBill != -1)
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn thanh toán " + table.Name +" ?","Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill);
                    ShowBill(table.Id);
                    LoadTable();
                }
            }
        }

        private void fTableManage_Load(object sender, EventArgs e)
        {

        }

        private void cboFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
