﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.IO;

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

        private void NextPage(int page)
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
            }
        }
        private void init_P8_1()
        {
            mainCanvas.Children.Clear();
            Page8_1 = new UserControls.Page8_1(this);
            mainCanvas.Children.Add(Page8_1);
            Page8_1.NextClick += NextClickEvent;
        }

        private void init_P8_2()
        {
            mainCanvas.Children.Clear();
            Page8_2 = new UserControls.Page8_2(this);
            mainCanvas.Children.Add(Page8_2);
            Page8_2.NextClick += NextClickEvent;
        }
        private void init_P8_3()
        {
            mainCanvas.Children.Clear();
            Page8_3 = new UserControls.Page8_3(this);
            mainCanvas.Children.Add(Page8_3);
            Page8_3.NextClick += NextClickEvent;
        }
        private void init_P8_4()
        {
            mainCanvas.Children.Clear();
            Page8_4 = new UserControls.Page8_4(this);
            mainCanvas.Children.Add(Page8_4);
            Page8_4.NextClick += NextClickEvent;
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
