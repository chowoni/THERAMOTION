using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.IO;

using ai_ucversion.UserControls;

using OpenCvSharp;
using OpenCvSharp.Extensions;


namespace ai_ucversion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        VideoCapture capCamera;
        UserControls.Page8_1 Page8_1; //무표정
        UserControls.Page8_2 Page8_2; //웃는 표정
        UserControls.Page8_3 Page8_3; //슬픈 표정
        UserControls.Page8_4 Page8_4; //화난 표정

        UserControls.Page11_1 Page11_1; //정면
        UserControls.Page11_2 Page11_2; //측면
        UserControls.Page11_3 Page11_3; //천추 위치 안내
        UserControls.Page11_4 Page11_4; //천추 선택

        public utility.DBClient db = new utility.DBClient();

        public MainWindow()
        {
            InitializeComponent();

            CurrentPage = 0;
        }

        private int _CurrentPage;
        public int CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                _CurrentPage = value;
                NextPage(value);
            }
        }

        private int _TotalPage;
        public int TotalPage
        {
            get { return _TotalPage; }
            set { _TotalPage = value; }
        }

        public void NextPage(int page)
        {
            mainCanvas.Children.Clear();

            //CurrentPage++;

            switch (page)
            {
                case 0: //감정표현(정신건강)
                    init_P8_1();
                    break;
                case 1:
                    init_P8_2();
                    break;
                case 2:
                    init_P8_3();
                    break;
                case 3:
                    init_P8_4();
                    break;
                case 4:
                    init_P11_1();
                    break;
                case 5:
                    init_P11_2();
                    break;
                case 6:
                    init_P11_3();
                    break;
                case 7:
                    init_P11_4();
                    break;
            }
        }

        WebCamVeiwport webCamVeiwport;
        private void init_P8_1()
        {
            mainCanvas.Children.Clear();
            Page8_1 = new UserControls.Page8_1(this);
            mainCanvas.Children.Add(Page8_1);
            Page8_1.NextClick += NextClickEvent;
            Page8_1.CaptureEvent += CaptureEvent;

            camCanvas.Children.Clear();
            webCamVeiwport = new WebCamVeiwport();
            webCamVeiwport.Visibility = Visibility.Visible;
            camCanvas.Children.Add(webCamVeiwport);
            webCamVeiwport.CamStart();

        }

        private void CaptureEvent(object? sender, EventArgs e)
        {
            switch (sender as System.Windows.Controls.UserControl)
            {
                case UserControls.Page8_1:
                    webCamVeiwport.Capture(0);
                    break;
                case UserControls.Page8_2:
                    webCamVeiwport.Capture(1);
                    break;
                case UserControls.Page8_3:
                    webCamVeiwport.Capture(2);
                    break;
                case UserControls.Page8_4:
                    webCamVeiwport.Capture(3);
                    webCamVeiwport.CamStop();
                    break;
            }
            
        }

        private void init_P8_2()
        {
            mainCanvas.Children.Clear();
            Page8_2 = new UserControls.Page8_2(this);
            mainCanvas.Children.Add(Page8_2);
            Page8_2.NextClick += NextClickEvent;
            Page8_2.CaptureEvent += CaptureEvent;


        }
        private void init_P8_3()
        {
            mainCanvas.Children.Clear();
            Page8_3 = new UserControls.Page8_3(this);
            mainCanvas.Children.Add(Page8_3);
            Page8_3.NextClick += NextClickEvent;
            Page8_3.CaptureEvent += CaptureEvent;
        }
        private void init_P8_4()
        {
            mainCanvas.Children.Clear();
            Page8_4 = new UserControls.Page8_4(this);
            mainCanvas.Children.Add(Page8_4);
            Page8_4.NextClick += NextClickEvent;
            Page8_4.CaptureEvent += CaptureEvent;
        }

        private void init_P11_1()
        {
            mainCanvas.Children.Clear();
            Page11_1 = new UserControls.Page11_1(this);
            mainCanvas.Children.Add(Page11_1);
            Page11_1.NextClick += NextClickEvent;
        }
        private void init_P11_2()
        {
            mainCanvas.Children.Clear();
            Page11_2 = new UserControls.Page11_2(this);
            mainCanvas.Children.Add(Page11_2);
            Page11_2.NextClick += NextClickEvent;
        }

        private void init_P11_3()
        {
            mainCanvas.Children.Clear();
            Page11_3 = new UserControls.Page11_3(this);
            mainCanvas.Children.Add(Page11_3);
            Page11_3.NextClick += NextClickEvent;
        }
        private void init_P11_4()
        {
            mainCanvas.Children.Clear();
            Page11_4 = new UserControls.Page11_4(this);
            mainCanvas.Children.Add(Page11_4);
            Page11_4.NextClick += NextClickEvent;
        }

        private void NextClickEvent(object sender, EventArgs e)
        {
            CurrentPage++;
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
