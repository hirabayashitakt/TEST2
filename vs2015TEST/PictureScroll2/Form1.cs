using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureScroll2
{
    public partial class Form1 : Form
    {

        public Bitmap img;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 画像指定
            img = new Bitmap(@"C:\Users\Public\Pictures\Sample Pictures\菊.bmp"); // ｷｬﾗｸﾀｰ画像


            // パネル内部のコントロール（ピクチャボックス）が、パネルより
            // も大きくなったら、スクロールバーが現れるように設定。
            panel1.AutoScroll = true;


            // ピクチャボックス（クライアント領域）の横幅で、最大値とする
            pictureBox1.ClientSize = new System.Drawing.Size(img.Width, img.Height);
            //pictureBox1.ClientSize.Width = img.Width;

            pictureBox1.Location = new System.Drawing.Point(0, 0);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(img, new Point(0, 0));
        }
    }
}
