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

namespace ai
{
    /// <summary>
    /// Page5_10.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page5_10 : Window
    {
        bool query = false, All = false;
        String[] tmp = new String[5];
        int[] answer = new int[11];
        public Page5_10(int[] data)
        {
            InitializeComponent();
            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");

            for (int i = 0; i < data.Length; i++)
                answer[i] = data[i];
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (query)
            {
                All = true;
                next.IsEnabled = true;

                btnTOscore();
            }
            else
            {
                next.IsEnabled = false;
                MessageBox.Show("문항에 대한 답을 완료해주세요.");
                next.IsEnabled = true;
                All = false;
            }

            if (next.IsEnabled == true && All == true)
            {
                ai.Page6 ChangeWInow = new ai.Page6() ;

                ChangeWInow.Show();
            }
        }

        private void QnA(object sender, RoutedEventArgs e)
        {
            query = (btn0.IsChecked == true) || (btn1.IsChecked == true) || (btn2.IsChecked == true) || (btn3.IsChecked == true) || (btn4.IsChecked == true);

            if (btn0.IsChecked == true)
            {
                a1.Visibility = Visibility.Visible;
                a1.Source = new BitmapImage(new Uri(@"/res/m3/T3_border.png", UriKind.Relative));
                a2.Visibility = Visibility.Collapsed;
                a3.Visibility = Visibility.Collapsed;
                a4.Visibility = Visibility.Collapsed;
                a5.Visibility = Visibility.Collapsed;
            }
            else if (btn1.IsChecked == true)
            {
                a2.Visibility = Visibility.Visible;
                a2.Source = new BitmapImage(new Uri(@"/res/m3/T3_border.png", UriKind.Relative));
                a1.Visibility = Visibility.Collapsed;
                a3.Visibility = Visibility.Collapsed;
                a4.Visibility = Visibility.Collapsed;
                a5.Visibility = Visibility.Collapsed;
            }
            else if (btn2.IsChecked == true)
            {
                a3.Visibility = Visibility.Visible;
                a3.Source = new BitmapImage(new Uri(@"/res/m3/T3_border.png", UriKind.Relative));
                a1.Visibility = Visibility.Collapsed;
                a2.Visibility = Visibility.Collapsed;
                a4.Visibility = Visibility.Collapsed;
                a5.Visibility = Visibility.Collapsed;
            }
            else if (btn3.IsChecked == true)
            {
                a4.Visibility = Visibility.Visible;
                a4.Source = new BitmapImage(new Uri(@"/res/m3/T3_border.png", UriKind.Relative));
                a1.Visibility = Visibility.Collapsed;
                a2.Visibility = Visibility.Collapsed;
                a3.Visibility = Visibility.Collapsed;
                a5.Visibility = Visibility.Collapsed;
            }
            else
            {
                a5.Visibility = Visibility.Visible;
                a5.Source = new BitmapImage(new Uri(@"/res/m3/T3_border.png", UriKind.Relative));
                a1.Visibility = Visibility.Collapsed;
                a2.Visibility = Visibility.Collapsed;
                a3.Visibility = Visibility.Collapsed;
                a4.Visibility = Visibility.Collapsed;
            }
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            answer[0] -= answer[9];

            ai.Page5_9 ChangeWInow = new ai.Page5_9(answer);

            ChangeWInow.Show();
        }

        private void btnTOscore()
        {
            int num = 0;

            tmp[0] = btn0.IsChecked.ToString();
            tmp[1] = btn1.IsChecked.ToString();
            tmp[2] = btn2.IsChecked.ToString();
            tmp[3] = btn3.IsChecked.ToString();
            tmp[4] = btn4.IsChecked.ToString();


            for (int i = 0; i < 5; i++)
            {
                if (tmp[i] == "True")
                {
                    num = i;
                    break;
                }
            }

            switch (num)
            {
                case 0:
                    answer[10] = 4;
                    answer[0] += answer[10];
                    break;
                case 1:
                    answer[10] = 3;
                    answer[0] += answer[10];
                    break;
                case 2:
                    answer[10] = 2;
                    answer[0] += answer[10];
                    break;
                case 3:
                    answer[10] = 1;
                    answer[0] += answer[10];
                    break;
                case 4:
                    answer[10] = 0;
                    answer[0] += answer[10];
                    break;
            }

            //CSV
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@DateTime.Now.ToString("[AI실증_설문]yyyy-MM-dd") + ".csv", true, Encoding.UTF8))
            {
                //필드 제목
                file.WriteLine("");
                file.WriteLine("오늘을 포함한 지난 한 달간의 스트레스(PSS)");
                file.WriteLine("문항 번호 , 응답");

                // 필드 값
                for (int i = 1; i < answer.Length; i++)
                {
                    file.WriteLine("{0},{1}", i, answer[i]);
                }
                file.WriteLine("{0},{1}", "Total", answer[0]);
            }
        }
    }
}
