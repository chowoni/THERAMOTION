using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Threading;

using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ai
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public string tmp;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void capture_Img(int num, VideoCapture capCamera, Mat img) //캡쳐, 저장
        {
            string save_name = DateTime.Now.ToString("yyyy-MM-dd-hh시mm분ss초");

            switch (num)
            {
                case 0: img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_basic.jpg");
                    break;
                case 1: img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_smile.jpg");
                    break ;
                    break ;
                case 2: img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_sad.jpg");
                    break;
                case 3: img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_angry.jpg");
                    break;
                case 4:
                    img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_kinnect(front).jpg");
                    break;
                case 5:
                    img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_kinnect(side).jpg");
                    break;
            }

            //capCamera.Release();
        }
    }
}
