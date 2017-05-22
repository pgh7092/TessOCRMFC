using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TessOCR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "이미지파일|*.jpg;*.jpeg;*.png";
            openFileDialog1.Title = "이미지열기";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != null)
                textBox1.Text = openFileDialog1.FileName;
        }
    }
}
