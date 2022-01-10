using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

//using OpenCvSharp;
//using OpenCvSharp.Extensions;

namespace ai_ucversion.UserControls
{
    /// <summary>
    /// Page8_1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page8_1 : UserControl
    {
        //VideoCapture capCamera;
        DispatcherTimer timer = new DispatcherTimer();
        bool loop = false;

        MainWindow main;

        public Page8_1(MainWindow mw)
        {
            InitializeComponent();
            InitializeCamera();

            main = mw;
            next.IsEnabled = false;

            disN.Source = new BitmapImage(new Uri(@"/res/disable.png", UriKind.Relative));
            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");
        }

        private void InitializeCamera()
        {
            timer.Interval = TimeSpan.FromMilliseconds(5000);

            timer.Tick += Timer_delay;
            timer.Start();

            ready();
        }

        private void Timer_delay(object sender, System.EventArgs e)
        {
            timer.Tick += Timer_Tick3;
            timer.Start();
        }

        private void ready()
        {
            timer.Interval = TimeSpan.FromMilliseconds(1000);

            cnt.Text = "3";
            timer.Tick += Timer_Tick3;
            timer.Start();
        }
        private void Timer_Tick3(object sender, System.EventArgs e)
        {
            cnt.Text = "2";
            timer.Tick += Timer_Tick2;
            timer.Start();
        }
        private void Timer_Tick2(object sender, System.EventArgs e)
        {
            cnt.Text = "1";
            timer.Tick += Timer_Tick1;
            timer.Start();
        }

        private void Timer_Tick1(object sender, System.EventArgs e)
        {
            cnt.Text = "0";
            timer.Tick += Timer_Tick0;
            timer.Start();
        }
        private void Timer_Tick0(object sender, System.EventArgs e)
        {
            disN.Source = new BitmapImage(new Uri(@"", UriKind.Relative));
            next.IsEnabled = true;

            rec.Opacity = 0;

            int num = 0;
            timer.Stop();

            CaptureEvent?.Invoke(this, e);
        }

        public event EventHandler CaptureEvent;


        //private void capture_Img() //캡쳐, 저장
        //{
        //    string save_name = DateTime.Now.ToString("yyyy-MM-dd-hh시mm분ss초");
        //    matImage.SaveImage(@"C:\Users\Kwon Cho Won\Desktop\capImg\" + save_name + "_basic.jpg");
        //}

        //private void PlayCamera()
        //{
        //    loop = true;
        //    while (loop)
        //    {
        //        capCamera.Read(matImage); // same as cvQueryFrame
        //        if (matImage.Empty()) break;
        //        //Thread.Sleep(sleepTime);
        //        //Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
        //        //{
        //        //    //var converted = Convert(BitmapConverter.ToBitmap(matImage));
        //        //    //imgViewport.Source = converted;
        //        //}));

        //        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
        //        {
        //            var converted = Convert(BitmapConverter.ToBitmap(matImage));
        //            imgViewport.Source = converted;
        //        }));
        //    }
        //}
        //public BitmapImage Convert(Bitmap src)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
        //    BitmapImage image = new BitmapImage();
        //    image.BeginInit();
        //    ms.Seek(0, SeekOrigin.Begin);
        //    image.StreamSource = ms;
        //    image.EndInit();
        //    return image;
        //}

        public event EventHandler NextClick;

        private void next_Click(object sender, RoutedEventArgs e)
        {
            NextClick?.Invoke(sender, e);
        }
        private void restart_Click(object sender, RoutedEventArgs e)
        {
            disR.Source = new BitmapImage(new Uri(@"/res/disable.png", UriKind.Relative));

            MessageBox.Show("재촬영을 시작합니다.");
            Thread.Sleep(1000);
            restart.IsEnabled = false;

            ready();
        }
    }
}
