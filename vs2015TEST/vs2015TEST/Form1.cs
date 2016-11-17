using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vs2015TEST
{
    public partial class Form1 : Form
    {

        //表示する画像
        private Bitmap currentImage;
        //倍率
        private double zoomRatio = 1d;
        //倍率変更後の画像のサイズと位置
        private Rectangle drawRectangle;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //表示する画像を読み込む
            if (currentImage != null)
            {
                currentImage.Dispose();
            }
            currentImage = new Bitmap(@"C:\Users\Public\Pictures\Sample Pictures\菊.bmp");
            //初期化
            drawRectangle = new Rectangle(0, 0, currentImage.Width, currentImage.Height);
            zoomRatio = 1d;
            //画像を表示する
            pictureBox1.Invalidate();


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
            drawRectangle.X = (int)Math.Round(pb.Width / 2d - imgPoint.X * zoomRatio);
            drawRectangle.Y = (int)Math.Round(pb.Height / 2d - imgPoint.Y * zoomRatio);

            //画像を表示する
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
    }
}
