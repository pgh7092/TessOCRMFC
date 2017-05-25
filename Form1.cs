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
using System.Threading;

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

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            folderBrowserDialog1.ShowNewFolderButton = true;
            if(folderBrowserDialog1.SelectedPath != null)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String test = textBox1.Text;

            Stream imageFileStream = File.OpenRead(test);
            byte[] byteArray = new byte[imageFileStream.Length];
            imageFileStream.Read(byteArray, 0, (int)imageFileStream.Length);
            TcpClient client = new TcpClient("220.149.11.210", 5007);
            textBox2.AppendText("waiting for a connection....\n");
            NetworkStream network = client.GetStream();
            textBox2.AppendText("Connect Success\n");
            network.Write(byteArray, 0, byteArray.GetLength(0));
            network.Flush();

            FileStream fileStream = new FileStream(textBox3.Text + "\\TesserOCR.txt", FileMode.Create, FileAccess.Write);
            BinaryWriter read = new BinaryWriter(fileStream);
            byte[] bytes = new byte[1024];
            read.Write(bytes, 0, bytes.Length);
            read.Flush();
            textBox2.AppendText("OCR Complete\n");

            client.Close();
        }
    }
}
