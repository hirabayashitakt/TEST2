using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureZoomScroll2
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


            // フォームの右端に縦スクロールバーをドッキング
           vScrollBar1.Dock = DockStyle.Right;


            // フォームの下端に横スクロールバーをドッキング
            hScrollBar1.Dock = DockStyle.Bottom;


            // フォーム中央の残りの部分にピクチャボックスをドッキング
 //           pictureBox1.Dock = DockStyle.Fill;


            // 縦スクロールバーの初期位置、最小値、最大値を設定
            this.vScrollBar1.Value = 0;
 //           this.vScrollBar1.Minimum = -1 * img.Height;
            this.vScrollBar1.Maximum = pictureBox1.ClientSize.Height;


            // 横スクロールバーの初期位置、最小値、最大値を設定
            this.hScrollBar1.Value = 0;
//            this.hScrollBar1.Minimum = -1 * img.Width;
            this.hScrollBar1.Maximum = pictureBox1.ClientSize.Width;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // 画像位置指定
            Point CharaPosition = new Point(); // ｷｬﾗｸﾀｰ位置
            CharaPosition.X = hScrollBar1.Value;
            CharaPosition.Y = vScrollBar1.Value;


            // 画像の描画
            e.Graphics.DrawImage(img, CharaPosition);
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // 今までに作成したイメージ画像をピクチャボックスに描画
            //  --- Paintイベントを強制発生させる。
            pictureBox1.Refresh();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // 今までに作成したイメージ画像をピクチャボックスに描画
            //  --- Paintイベントを強制発生させる。
            pictureBox1.Refresh();
        }
    }
}
