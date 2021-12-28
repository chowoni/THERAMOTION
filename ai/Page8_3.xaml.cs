using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ai
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Page8_3 : System.Windows.Window
    {
        VideoCapture capCamera;
        WriteableBitmap wb;
        bool loop = false;

        DispatcherTimer timer = new DispatcherTimer();
        Mat matImage = new Mat();

        MainWindow main = new MainWindow();

        public Page8_3()
        {
            InitializeComponent();
            InitializeCamera();

            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");
        }

        private void InitializeCamera()
        {
            capCamera = VideoCapture.FromCamera(0);
            ready();
        }

        private void ready()
        {
            new Thread(PlayCamera).Start();

            //음성 출력

            img.Source = new BitmapImage(new Uri(@"/img/n3.png", UriKind.Relative));

            timer.Interval = TimeSpan.FromMilliseconds(1000);

            timer.Tick += Timer_Tick3;
            timer.Start();
        }
        private void Timer_Tick3(object sender, System.EventArgs e)
        {
            img.Source = new BitmapImage(new Uri(@"/img/n2.png", UriKind.Relative));
            timer.Tick += Timer_Tick2;
            timer.Start();
        }
        private void Timer_Tick2(object sender, System.EventArgs e)
        {
            img.Source = new BitmapImage(new Uri(@"/img/n1.png", UriKind.Relative));
            timer.Tick += Timer_Tick1;
            timer.Start();
        }

        private void Timer_Tick1(object sender, System.EventArgs e)
        {
            img.Source = new BitmapImage(new Uri(@"/IMG/camera.png", UriKind.Relative));
            timer.Tick += Timer_Tick0;
            timer.Start();
        }
        private void Timer_Tick0(object sender, System.EventArgs e)
        {
            int num = 3;
            timer.Stop();

            //캡쳐 함수 호출
            main.capture_Img(num, capCamera, matImage);
        }

        private void PlayCamera()
        {
            loop = true;
            while (loop)
            {
                capCamera.Read(matImage); // same as cvQueryFrame
                if (matImage.Empty()) break;

                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
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

        private void next_Click(object sender, RoutedEventArgs e)
        {
            loop = false;

            ai.Page8_4 ChangeWInow = new ai.Page8_4();

            ChangeWInow.Show();
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("재촬영을 시작합니다.");
            Thread.Sleep(1000);
            restart.IsEnabled = false;

            ready();
        }
    }
}