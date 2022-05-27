using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Excel = Microsoft.Office.Interop.Excel;
namespace Assignment3
{
    public partial class Form2 : Form
    {

        _Excel.Application Excel = new _Excel.Application();
        _Excel.Workbook wb;
        _Excel.Worksheet sheet;
        _Excel.Range range ;

        public Form2()
        {
            InitializeComponent();
            wb = Excel.Workbooks.Open(@"C:\Users\Kiran Ramzan\Desktop\Book1.xlsx");
            sheet = wb.ActiveSheet;
        }

        private string Remove920(string Number)
        {
            string str = Number;

            if (str.StartsWith("92"))
            {
                str = str.Substring(2);
            } 

            else if(str.StartsWith("0"))
            {
                str = str.Substring(1);
            } 
            
            return str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n = "920306755";
            MessageBox.Show(n.Substring(2));
            //webBrowser1.Navigate(textBox1.Text);
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            //string RowText = Convert.ToString(range.Cells[2, 1].Value);
            //MessageBox.Show(RowText.ToString());

            range = sheet.UsedRange;
            int rowcount = range.Rows.Count;
            string[] data = new string[rowcount];
            for (int i = 1; i < rowcount; i++)
            {
                string RowText = Convert.ToString(range.Cells[i, 1].Value);                
                data[i]=Remove920(RowText);
            }
            wb.Close();
        }
    }
}
