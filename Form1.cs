using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

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

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = new Byte[1024];
            String test = textBox1.Text;

            //서버로 이미지 전송
            using (var tcp = new TcpClient("192.168.188.128", 5007))
            {
                byte[] image = File.ReadAllBytes(test);
                tcp.GetStream().Write(image, 0, image.Length);
            }

        }
    }
}
