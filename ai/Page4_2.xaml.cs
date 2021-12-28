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
    /// Page4_2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page4_2 : Window
    {
        bool query = false, All = false;
        String[] tmp = new String[5];
        int[] answer = new int[8]; //index 0 : 총 합, 1~8 : 개별 문항에 대한 점수
        public Page4_2(int[] data)
        {
            InitializeComponent();
            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");

            for (int i=0; i<data.Length; i++)
                answer[i] = data[i];
        }
        private void previous_Click(object sender, RoutedEventArgs e)
        {
            answer[0] -= answer[1];

            ai.Page4_1 ChangeWInow = new ai.Page4_1(answer);

            ChangeWInow.Show();
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
                ai.Page4_3 ChangeWInow = new ai.Page4_3(answer);

                ChangeWInow.Show();
            }
        }
        private void QnA(object sender, RoutedEventArgs e)
        {
            query = (btn0.IsChecked == true) || (btn1.IsChecked == true) || (btn2.IsChecked == true) || (btn3.IsChecked == true);

            if (btn0.IsChecked == true)
            {
                a1.Visibility = Visibility.Visible;
                a1.Source = new BitmapImage(new Uri(@"/res/T2_border.png", UriKind.Relative));
                a2.Visibility = Visibility.Collapsed;
                a3.Visibility = Visibility.Collapsed;
                a4.Visibility = Visibility.Collapsed;
            }
            else if (btn1.IsChecked == true)
            {
                a2.Visibility = Visibility.Visible;
                a2.Source = new BitmapImage(new Uri(@"/res/T2_border.png", UriKind.Relative));
                a1.Visibility = Visibility.Collapsed;
                a3.Visibility = Visibility.Collapsed;
                a4.Visibility = Visibility.Collapsed;
            }
            else if (btn2.IsChecked == true)
            {
                a3.Visibility = Visibility.Visible;
                a3.Source = new BitmapImage(new Uri(@"/res/T2_border.png", UriKind.Relative));
                a1.Visibility = Visibility.Collapsed;
                a2.Visibility = Visibility.Collapsed;
                a4.Visibility = Visibility.Collapsed;
            }
            else
            {
                a4.Visibility = Visibility.Visible;
                a4.Source = new BitmapImage(new Uri(@"/res/T2_border.png", UriKind.Relative));
                a1.Visibility = Visibility.Collapsed;
                a2.Visibility = Visibility.Collapsed;
                a3.Visibility = Visibility.Collapsed;
            }
        }
        private void btnTOscore()
        {
            int total = answer[0];
            int num = 0;

            tmp[1] = btn0.IsChecked.ToString();
            tmp[2] = btn1.IsChecked.ToString();                            
            tmp[3] = btn2.IsChecked.ToString();                       
            tmp[4] = btn3.IsChecked.ToString();


            for (int i = 1; i < 5; i++)
            {
                if (tmp[i] == "True")
                {
                    num = i;
                    break;
                }
            }

            switch (num)
            {
                case 1:
                    answer[2] = 0;
                    answer[0] += answer[2];
                    break;
                case 2:
                    answer[2] = 1;
                    answer[0] += answer[2];
                    break;
                case 3:
                    answer[2] = 2;
                    answer[0] += answer[2];
                    break;
                case 4:
                    answer[2] = 3;
                    answer[0] += answer[2];
                    break;
            }

        }
    }
}
