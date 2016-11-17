using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureZoomScroll
{
    public partial class Form1 : Form
    {
        //表示する画像
        private Bitmap currentImage;
        //倍率
        private double zoomRatio = 1d;
        //倍率変更後の画像のサイズと位置
        private Rectangle drawRectangle;

        private int WidthImgPoint = 0;
        private int HeighImgPoint = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // パネル内部のコントロール（ピクチャボックス）が、パネルより
            // も大きくなったら、スクロールバーが現れるように設定。
            panel1.AutoScroll = true;

            //panel1.Scroll

            // PictureBoxコントロールのサイズを画像の実サイズにする
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureBox1.Name = "pictureBox1";
            pictureBox1.Location = new Point(0, 0);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //表示する画像を読み込む
            if (currentImage != null)
            {
                currentImage.Dispose();
            }
            // currentImage = new Bitmap(textBox1.Text);
            currentImage = new Bitmap(@"C:\Users\Public\Pictures\Sample Pictures\菊.bmp");
            //初期化
            WidthImgPoint = 0;
            HeighImgPoint = 0;

            drawRectangle = new Rectangle(WidthImgPoint, HeighImgPoint, currentImage.Width, currentImage.Height);

            // ピクチャボックス（クライアント領域）の横幅で、最大値とする
            pictureBox1.ClientSize = new System.Drawing.Size(currentImage.Width, currentImage.Height);
            //pictureBox1.ClientSize.Width = img.Width;
            pictureBox1.Location = new System.Drawing.Point(0, 0);

            zoomRatio = 1d;
            //画像を表示する
            //pictureBox1.Image = currentImage;
            pictureBox1.Invalidate();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (currentImage != null)
            {
                //画像を指定された位置、サイズで描画する
                e.Graphics.DrawImage(currentImage, drawRectangle);
  
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            //クリックされた位置を画像上の位置に変換
            Point imgPoint = new Point(
                (int)Math.Round((e.X - drawRectangle.X) / zoomRatio),
                (int)Math.Round((e.Y - drawRectangle.Y) / zoomRatio));

            //倍率を変更する
            if (e.Button == MouseButtons.Left)
            {
                zoomRatio *= 2d;
            }
            else if (e.Button == MouseButtons.Right)
            {
                zoomRatio *= 0.5d;
            }

            //倍率変更後の画像のサイズと位置を計算する
            drawRectangle.Width = (int)Math.Round(currentImage.Width * zoomRatio);
            drawRectangle.Height = (int)Math.Round(currentImage.Height * zoomRatio);
            //              drawRectangle.X = (int)Math.Round(pb.Width / 2d - imgPoint.X * zoomRatio);
            //              drawRectangle.Y = (int)Math.Round(pb.Height / 2d - imgPoint.Y * zoomRatio);

            WidthImgPoint = System.Math.Abs((int)Math.Round(pb.Width / 2d - imgPoint.X * zoomRatio));
            HeighImgPoint = System.Math.Abs((int)Math.Round(pb.Height / 2d - imgPoint.Y * zoomRatio));



            // ピクチャボックス（クライアント領域）の横幅で、最大値とする
            pictureBox1.ClientSize = new System.Drawing.Size(drawRectangle.Width, drawRectangle.Height);
            //               pictureBox1.Location = new System.Drawing.Point(0, 0);


            panel1.AutoScrollPosition = new Point(WidthImgPoint, HeighImgPoint);

            //画像を表示する
            pictureBox1.Invalidate();


        }


    }
}
