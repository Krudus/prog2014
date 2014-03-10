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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum = 0, B, H, P, R, Ch, K, A, T, Sh;
            if (checkBox1.Checked)
            {
                B = Convert.ToInt32(numericUpDown1.Value);
                sum = sum + (B * 30);
            }
            if (checkBox2.Checked)
            {
                H = Convert.ToInt32(numericUpDown2.Value);
                sum = sum + (H * 35);
            }
            if (checkBox3.Checked)
            {
                P = Convert.ToInt32(numericUpDown3.Value);
                sum = sum + (P * 50);

            }
            if (checkBox4.Checked)
            {
                R = Convert.ToInt32(numericUpDown4.Value);
                sum = sum + (R * +90);
            }
            if (checkBox5.Checked)
            {
                Ch = Convert.ToInt32(numericUpDown5.Value);
                sum = sum + (Ch * 50);
            }
            if (checkBox6.Checked)
            {
                K = Convert.ToInt32(numericUpDown6.Value);
                sum = sum + (K * 45);
            }
            if (checkBox7.Checked)
            {
                A = Convert.ToInt32(numericUpDown7.Value);
                sum = sum + (A * +65);
            }
                if (checkBox8.Checked)
                {
                    T = Convert.ToInt32(numericUpDown8.Value);
                    sum = sum + (T * 50);
                }
                if (checkBox9.Checked)
                {
                    Sh = Convert.ToInt32(numericUpDown9.Value);
                    sum = sum + (Sh * 45);
                }

                label10.Text = sum.ToString();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Заказ|*.internetshop" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var fileName = sfd.FileName;
                ShopData pd = new ShopData();
                pd.ItemType = new List<ShopType>();
                if (checkBox1.Checked)
                pd.ItemType.Add(ShopType.Bul);
                if (checkBox2.Checked)
                    pd.ItemType.Add(ShopType.Hleb);
                if (checkBox3.Checked)
                    pd.ItemType.Add(ShopType.Pon);
               if (checkBox4.Checked )
                    pd.ItemType.Contains(ShopType.Red);
               if( checkBox5.Checked)
                    pd.ItemType.Contains(ShopType.Chai);
               if( checkBox6.Checked )
                    pd.ItemType.Contains(ShopType.Kol);
               if( checkBox4.Checked)
                    pd.ItemType.Contains(ShopType.Red);
               if( checkBox5.Checked)
                    pd.ItemType.Contains(ShopType.Chai);
               if( checkBox6.Checked )
                    pd.ItemType.Contains(ShopType.Kol);
           if(     checkBox7.Checked )
                    pd.ItemType.Contains(ShopType.A);
             if   (   checkBox8.Checked )
                    pd.ItemType.Contains(ShopType.T);
            if(    checkBox9.Checked )
                    pd.ItemType.Contains(ShopType.Sh);
                

                XmlSerializer xs = new XmlSerializer(typeof(ShopData));
                var fileStream = File.Create(fileName);
                xs.Serialize(fileStream, pd);
                fileStream.Close();
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Заказ|*.internetshop" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var xs = new XmlSerializer(typeof(ShopData));
                var file = File.Open(ofd.FileName, FileMode.Open);
                var pd = (ShopData)xs.Deserialize(file);
                file.Close();

                checkBox1.Checked = pd.ItemType.Contains(ShopType.Bul);
                checkBox2.Checked = pd.ItemType.Contains(ShopType.Hleb);
                checkBox3.Checked = pd.ItemType.Contains(ShopType.Pon);
                checkBox4.Checked = pd.ItemType.Contains(ShopType.Red);
                checkBox5.Checked = pd.ItemType.Contains(ShopType.Chai);
                checkBox6.Checked = pd.ItemType.Contains(ShopType.Kol);
                checkBox4.Checked = pd.ItemType.Contains(ShopType.Red);
                checkBox5.Checked = pd.ItemType.Contains(ShopType.Chai);
                checkBox6.Checked = pd.ItemType.Contains(ShopType.Kol);
                checkBox7.Checked = pd.ItemType.Contains(ShopType.A);
                checkBox8.Checked = pd.ItemType.Contains(ShopType.T);
                checkBox9.Checked = pd.ItemType.Contains(ShopType.Sh);

            }
        }
         
  
         private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }
  
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
        
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void label18_Click(object sender, EventArgs e)
        {
        
        }

        private void label17_Click(object sender, EventArgs e)
        {
        
        }

       
        private void button4_Click(object sender, EventArgs e)
        { 
   
            var pr = new XtraReport1();
            ShopData pd = CreateShopData();
            pr.DataSource = new BindingSource() { DataSource = pd };
            pr.ShowPreview();
        
        }

        public class Data
        {
            public List<Option> M { get; set; }

        }
        public class Option
        {
            public int Age { get; set; }
            public bool Russia { get; set; }
            public bool English { get; set; }
            public bool French { get; set; }
            public bool one { get; set; }
            public bool three { get; set; }
            public bool more { get; set; }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            checkBox1.Checked = listBox1.SelectedItem != null;
        }
    }
    public class ShopData
    {
        //List<ShopType> ItemType {get;set;}
        public List<ShopType> ItemType { get; set; }
        /*pd.ItemType = new List<ShopType>();
        pd.ItemType.Add(ShopType.Plita);
        public List<ShopType> ItemType { get; set; }*/
    }
    public enum ShopType
    {
        Bul,Hleb,Pon,Red,Kol,Chai,A,T,Sh
    }
}
