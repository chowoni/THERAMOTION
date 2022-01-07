using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ai_ucversion.UserControls
{
    /// <summary>
    /// WebCamVeiwport.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WebCamVeiwport : UserControl
    {
        VideoCapture capCamera;
        DispatcherTimer timer = new DispatcherTimer();
        bool loop = false;

        Mat matImage = new Mat();
        MainWindow main;

        public WebCamVeiwport()
        {
            InitializeComponent();
            InitializeCamera();
        }

        private void InitializeCamera()
        {
            capCamera = VideoCapture.FromCamera(0);
        }


        Task cameraTask;
        public void CamStart()
        {
            cameraTask = new Task(PlayCamera);
            loop = true;
            cameraTask.Start();
        }

        public void CamStop()
        {
            loop = false;
            cameraTask.Wait(100);
        }

        private void PlayCamera()
        {
            loop = true;
            while (loop)
            {
                capCamera.Read(matImage); // same as cvQueryFrame
                if (matImage.Empty()) break;
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    var converted = Convert(BitmapConverter.ToBitmap(matImage));
                    imgViewport.Source = converted;
                }));
            }
        }

        public BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }


        public void Capture(int num)
        {
            capture_Img(num, capCamera, matImage);
        }


        public void capture_Img(int num, VideoCapture capCamera, Mat img) //캡쳐, 저장
        {
            string save_name = DateTime.Now.ToString("yyyy-MM-dd-hh시mm분ss초");

            switch (num)
            {
                case 0:
                    img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_basic.jpg");
                    break;
                case 1:
                    img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_smile.jpg");
                    break;
                case 2:
                    img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_sad.jpg");
                    break;
                case 3:
                    img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_angry.jpg");
                    break;
                case 4:
                    img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_kinnect(front).jpg");
                    break;
                case 5:
                    img.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_kinnect(side).jpg");
                    break;
            }
        }
    }
}
