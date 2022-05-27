using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class Form1 : Form
    {
        DB db=new DB();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //string name = "Kiran Ramzan";
            //string[] namesplit = name.Split(' ');

            //for (int i = 0; i < namesplit.Length; i++)
            //{
            //    MessageBox.Show(namesplit[i]);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.GetTable(@"SELECT *  from Table_MPA");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
              
                //Panel

                Panel p = new Panel();
                p.Width = 500;
                p.Height = 150;
                p.BackColor = Color.White;
                p.BorderStyle = BorderStyle.FixedSingle;

                //Picture
                PictureBox pb = new PictureBox();
                pb.Width = 100;
                pb.Height = 140;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Controls.Add(pb);

                //Partyflag
                PictureBox pb2 = new PictureBox();
                pb2.Width = 50;
                pb2.Height = 19;
                pb2.Location = new Point(70, 1);
                pb2.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Controls.Add(pb2);

                //Label Name
                Label lbl = new Label();
                lbl.Location = new Point(130, 10);
                lbl.ForeColor = Color.Blue;
                lbl.Font= new Font("Segoe UI", 10, FontStyle.Bold); 
                lbl.AutoSize = true;
                p.Controls.Add(lbl);
                
                //label  consituency
                Label lbl2 = new Label();
                lbl2.Location = new Point(130, 40);
                lbl2.ForeColor = Color.Black;
                lbl2.AutoSize = true;
                p.Controls.Add(lbl2);


                //label partyname
                Label lbl3 = new Label();
                lbl3.Location = new Point(130,70);
                lbl3.AutoSize= true;
                lbl3.ForeColor = Color.Black;
                p.Controls.Add(lbl3);

                
                string fname = dt.Rows[i][1].ToString();
                string femail = dt.Rows[i][6].ToString();
                lbl.Text = fname + " | " + femail;


                string fname2 = dt.Rows[i][2].ToString() ;
                lbl2.Text = fname2  ;
                

                string fname3 = dt.Rows[i][3].ToString();
                lbl3.Text = fname3;

                byte[] fileData = (byte[])dt.Rows[i][7];
                ImageConverter converter = new ImageConverter();
                pb.Image = (Image)converter.ConvertFrom(fileData);

                
                byte[] fileData2 = (byte[])dt.Rows[i][4];
                ImageConverter img = new ImageConverter();
                pb2.Image=(Image)img.ConvertFrom(fileData2);

                
                flowLayoutPanel1.Controls.Add(p);
            }
        }

      
    }
}
