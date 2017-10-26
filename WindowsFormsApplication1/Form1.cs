using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().ToString().Length != 0)
            {
                this.textBox1.Text = Helper.DEncrypt.Security.EncryptDES(this.textBox1.Text.Trim());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().ToString().Length != 0)
            {
                this.textBox1.Text = Helper.DEncrypt.Security.DecryptDES(this.textBox1.Text.Trim());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order_Bll order_bll = new Order_Bll();

            List<Order> order_list = new List<Order>();


            order_list = order_bll.GetList();
            this.exDataGridView1.AllowUserToAddRows = true;
            this.exDataGridView1.AllowUserToDeleteRows = true;

            this.exDataGridView1.Columns.Clear();
            this.exDataGridView1.DataSource = new Helper.Binding.BindingCollection<Order>(order_list);
            
            this.exDataGridView1.AddColumn("check", "", ColumnType: new DataGridViewCheckBoxColumn(), IFReadOnly: false, Aligment: DataGridViewContentAlignment.MiddleCenter, DisplayWidth: 20);
            this.exDataGridView1.AddColumn("order_no", "编号", Aligment: DataGridViewContentAlignment.MiddleLeft, IFReadOnly: false);
            this.exDataGridView1.AddColumn("name", "名称", Aligment: DataGridViewContentAlignment.MiddleLeft,IFReadOnly:false);
            this.exDataGridView1.AddColumn("CreateDate", "建立日期", Aligment: DataGridViewContentAlignment.MiddleLeft, IFReadOnly: false);
            this.exDataGridView1.AddColumn("id", "id", Aligment: DataGridViewContentAlignment.MiddleLeft, IFReadOnly: false);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            


            
            Order_Bll ob = new Order_Bll();

            List<Order> myList = ((IList<Order>)this.exDataGridView1.DataSource).ToList();
            ob.saveLO(myList);
            
        }
    }
}
