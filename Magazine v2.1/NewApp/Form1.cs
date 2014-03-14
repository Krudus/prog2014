using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraReports.UI;

namespace NewApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        void RecalcTotalTable() 
        {
            int s = 0, a, b, c, d;
            if (checkBox1.Checked)
            {                
                
                a = Convert.ToInt32(numericUpDown1.Value);
                s = s + (a * 50);
            }
            else
            {
               
            }
            if (checkBox2.Checked)
            {                
               
                b = Convert.ToInt32(numericUpDown2.Value);
                s = s + (b * 60);
            }
            else
            {
                
            }
            if (checkBox3.Checked)
            {                
               
                c = Convert.ToInt32(numericUpDown3.Value);
                s = s + (c * 45);
            }
            else
            {
               
            }
            if (checkBox4.Checked)
            {                
               
                d = Convert.ToInt32(numericUpDown4.Value);
                s = s + (d * 30);
            }
            else
            {
                
            }
            label10.Text = s.ToString();

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int s = 0, a, b, c, d;
            if (checkBox1.Checked)
            {
                a = Convert.ToInt32(numericUpDown1.Value);
                s = s + (a*50);
            }
            if (checkBox2.Checked)
            {
                b = Convert.ToInt32(numericUpDown2.Value);
                s = s + (b*60);
            } 
            if (checkBox3.Checked)
            {
                c = Convert.ToInt32(numericUpDown3.Value);
                s = s + (c*45);
            }
            if (checkBox4.Checked)
            {
                d = Convert.ToInt32(numericUpDown4.Value);
                s = s + (d*30);
            }
            label10.Text = s.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Заказ|*.shopm" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var fileName = sfd.FileName;                
                ShopData sd = new ShopData();
                var line = new ProductList();
                sd.Items = new List<ProductList>();
                if (checkBox1.Checked)
                   
                    sd.Items.Add(new ProductList() { Type = ProductType.Chai, Quantity = (Int32) numericUpDown1.Value });
                if (checkBox2.Checked)
                    
                    sd.Items.Add(new ProductList() { Type = ProductType.Kofe, Quantity = (Int32)numericUpDown2.Value });
                if (checkBox3.Checked)
                    
                    sd.Items.Add(new ProductList() { Type = ProductType.Kola, Quantity = (Int32)numericUpDown3.Value });
                if (checkBox4.Checked)
                    
                    sd.Items.Add(new ProductList() { Type = ProductType.Hleb, Quantity = (Int32)numericUpDown4.Value });
                

                XmlSerializer xs = new XmlSerializer(typeof(ShopData));
                var fileStream = File.Create(fileName);
                xs.Serialize(fileStream, sd);
                fileStream.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Заказ|*.shopm" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var xs = new XmlSerializer(typeof(ShopData));
                var file = File.Open(ofd.FileName, FileMode.Open);
                var sd = (ShopData)xs.Deserialize(file);
                file.Close();

                foreach(var line in sd.Items)
                {
                    if(line.Type==ProductType.Chai)
                    {                
                        checkBox1.Checked = true; numericUpDown1.Value = line.Quantity;
                    }
                    if (line.Type == ProductType.Kofe)
                    {
                        checkBox2.Checked = true; numericUpDown2.Value = line.Quantity;
                    }
                    if (line.Type == ProductType.Kola)
                    {
                        checkBox3.Checked = true; numericUpDown3.Value = line.Quantity;
                    }
                    if (line.Type == ProductType.Hleb)
                    {
                        checkBox4.Checked = true; numericUpDown4.Value = line.Quantity;
                    }
                }               
            }
        }

        private ShopData CreateShopData()
        {
            ShopData sd = new ShopData();
            sd.Items = new List<ProductList>();
            foreach (ProductList el in listBox1.Items)
            {
                sd.Items.Add(el);
            }
            return sd;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = listBox1.SelectedItem != null;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var xr = new XtraReport1();
            ShopData sd = CreateShopData();
            xr.DataSource = new BindingSource() { DataSource = sd };
            xr.ShowPreview();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var pl = new ProductList
            {
                Chai = checkBox1.Checked,
                Kofe = checkBox2.Checked,
                Kola = checkBox3.Checked,
                Hleb = checkBox4.Checked,
                n1 = numericUpDown1.Value,
                n2 = numericUpDown2.Value,
                n3 = numericUpDown3.Value,
                n4 = numericUpDown4.Value,
                n5 = dateTimePicker3.Value,
                };
            if (listBox1.Items.Count < 1)
            {
                listBox1.Items.Add(pl);
            }            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            listBox1.Items.Clear();
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
            numericUpDown4.Value = 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class ShopData
    {
        public ProductType product { get; set; }
        public List<ProductList> Items { get; set; }

        [XmlIgnore]
        public string DataField 
        { 
            get
            {   
                return "fsf".ToString();
            }
        }
    }
    public class ProductList
    {
        public ProductType Type { get; set; }
        public int Quantity { get; set; }
        public bool Chai    { get; set; }
        public bool Kofe { get; set; }
        public bool Kola { get; set; }
        public bool Hleb { get; set; }
        public decimal n1 { get; set; }
        public decimal n2 { get; set; }
        public decimal n3 { get; set; }
        public decimal n4 { get; set; }
        public DateTime n5 = DateTime.ParseExact("20111126", "yyyyMdd", null);

        [XmlIgnore]
        public string Description 
        { 
            get 
            { 
                return this.ToString(); 
            } 
        }

        public override string ToString()
        {
            var s = ".";
            if (Chai)
                s = "Чай " + n1 + "шт, " + s;
            if (Kofe)
                s = "Кофе " + n1 + "шт, " + s;
            if (Kola)
                s = "Кола " + n1 + "шт, " + s;
            if (Hleb)
                s = "Хлеб " + n1 + "шт, " + s;
            return s;
        }
    }
    public enum ProductType
    {
        Chai,Kofe,Kola,Hleb
    }
}
