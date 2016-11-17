using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureScroll
{
    /**
   ※フォームデザイナー使用バージョン
   1.Panelコントロールをフォームに追加します。ここでは追加したPanelコントロールの名前が"panel1"であるとします。
   2.panel1のAutoScrollプロパティをTrueに変更します。
   3.PictureBoxコントロールをpanel1内に追加します。この時必ずpanel1の中に入れてください。ここでは追加したPictureBoxコントロールの名前が"pictureBox1"であるとします。
   4.pictureBox1のLocationプロパティを "0, 0" にします。
   5.pictureBox1のSizeModeプロパティをAutoSizeにします。（このようにすると、Imageプロパティで画像を表示させたとき、画像の大きさに合わせてピクチャボックスの大きさが自動的に変わるようになります。）
   6.pictureBox1のImageプロパティに表示させる画像を指定します。


    */

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
