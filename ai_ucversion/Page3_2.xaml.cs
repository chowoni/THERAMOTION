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

namespace ai_ucversion
{
    /// <summary>
    /// Page3_2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page3_2 : Window
    {
        bool query6 = false, query7 = false, query8 = false, query9 = false, query10 = false, All = false;
        int total = 0;
        int i = 5;
        bool ch6, ch7, ch8, ch9, ch10 = false;

        string[] arr = new string[5];
        int[] answer = new int[11]; //[0] : 3_1 총 점, [1] ~ [10] : 1~10 문항 답변

        MainWindow main = new MainWindow();

        public Page3_2(int[] data)
        {
            InitializeComponent();
            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");
            a6.Source = new BitmapImage(new Uri(@"/res/border.png", UriKind.Relative));

            for (int i = 0; i < data.Length; i++)
                answer[i] = data[i];

        }

        private void Q_6_Checked(object sender, RoutedEventArgs e)
        {
            if (T_6.IsChecked == false)
            {
                C6T.Visibility = Visibility.Visible;
                C6T.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C6F.Visibility = Visibility.Collapsed;
            }
            else
            {
                C6F.Visibility = Visibility.Visible;
                C6F.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C6T.Visibility = Visibility.Collapsed;
            }

            a6.Visibility = Visibility.Collapsed;
            a7.Source = new BitmapImage(new Uri(@"/res/border.png", UriKind.Relative));

            gL6.Source = new BitmapImage(new Uri(@"/res/L.png", UriKind.Relative));
            gF6.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));
            gT6.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));

            if (gL6.Source != null && ch6 == false)
            {
                i++;
                cnt.Text = "0" + i.ToString();
                if (i == 10)
                    cnt.Text = "10";
                ch6 = true;
            }
        }

        private void Q_7_Checked(object sender, RoutedEventArgs e)
        {
            if (T_7.IsChecked == true)
            {
                C7T.Visibility = Visibility.Visible;
                C7T.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C7F.Visibility = Visibility.Collapsed;
            }
            else
            {
                C7F.Visibility = Visibility.Visible;
                C7F.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C7T.Visibility = Visibility.Collapsed;
            }

            a7.Visibility = Visibility.Collapsed;
            a8.Source = new BitmapImage(new Uri(@"/res/border.png", UriKind.Relative));

            gL7.Source = new BitmapImage(new Uri(@"/res/L.png", UriKind.Relative));
            gF7.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));
            gT7.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));

            if (gL7.Source != null && ch7 == false)
            {
                i++;
                cnt.Text = "0" + i.ToString();
                if (i == 10)
                    cnt.Text = "10";
                ch7 = true;
            }
        }

        private void Q_8_Checked(object sender, RoutedEventArgs e)
        {
            if (T_8.IsChecked == true)
            {
                C8T.Visibility = Visibility.Visible;
                C8T.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C8F.Visibility = Visibility.Collapsed;
            }
            else
            {
                C8F.Visibility = Visibility.Visible;
                C8F.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C8T.Visibility = Visibility.Collapsed;
            }

            a8.Visibility = Visibility.Collapsed;
            a9.Source = new BitmapImage(new Uri(@"/res/border.png", UriKind.Relative));

            gL8.Source = new BitmapImage(new Uri(@"/res/L.png", UriKind.Relative));
            gF8.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));
            gT8.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));

            if (gL8.Source != null && ch8 == false)
            {
                i++;
                cnt.Text = "0" + i.ToString();
                if (i == 10)
                    cnt.Text = "10";
                ch8 = true;
            }
        }

        private void Q_9_Checked(object sender, RoutedEventArgs e)
        {
            if (T_9.IsChecked == true)
            {
                C9T.Visibility = Visibility.Visible;
                C9T.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C9F.Visibility = Visibility.Collapsed;
            }
            else
            {
                C9F.Visibility = Visibility.Visible;
                C9F.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C9T.Visibility = Visibility.Collapsed;
            }

            a9.Visibility = Visibility.Collapsed;
            a10.Source = new BitmapImage(new Uri(@"/res/border.png", UriKind.Relative));

            gL9.Source = new BitmapImage(new Uri(@"/res/L.png", UriKind.Relative));
            gF9.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));
            gT9.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));

            if (gL9.Source != null && ch9 == false)
            {
                i++;
                cnt.Text = "0" + i.ToString();
                if (i == 10)
                    cnt.Text = "10";
                ch9 = true;
            }
        }

        private void Q_10_Checked(object sender, RoutedEventArgs e)
        {
            if (T_10.IsChecked == true)
            {
                C10T.Visibility = Visibility.Visible;
                C10T.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C10F.Visibility = Visibility.Collapsed;
            }
            else
            {
                C10F.Visibility = Visibility.Visible;
                C10F.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C10T.Visibility = Visibility.Collapsed;
            }

            a10.Visibility = Visibility.Collapsed;

            gL10.Source = new BitmapImage(new Uri(@"/res/L.png", UriKind.Relative));
            gF10.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));
            gT10.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));

            if (gL10.Source != null && ch10 == false)
            {
                i++;
                cnt.Text = "0" + i.ToString();
                if (i == 10)
                    cnt.Text = "10";
                ch10 = true;
            }
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 11; i++)
            {
                answer[i] = 0;
            }

            answer[0] = 0;

            ai_ucversion.Page3_1 ChangeWInow = new ai_ucversion.Page3_1();

            ChangeWInow.Show();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (query6 && query7 && query8 && query9 && query10)

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
                ai_ucversion.Page4_1 ChangeWInow = new ai_ucversion.Page4_1(null);

                ChangeWInow.Show();
            }
        }
        private void QnA(object sender, RoutedEventArgs e)
        {
            query6 = (F_6.IsChecked == true) || (T_6.IsChecked == true);

            query7 = (F_7.IsChecked == true) || (T_7.IsChecked == true);

            query8 = (F_8.IsChecked == true) || (T_8.IsChecked == true);

            query9 = (F_9.IsChecked == true) || (T_9.IsChecked == true);

            query10 = (F_10.IsChecked == true) || (T_10.IsChecked == true);
        }

        private void btnTOscore()
        {
            int[] An = new int[10];

            arr[0] = T_6.IsChecked.ToString();
            arr[1] = T_7.IsChecked.ToString();
            arr[2] = T_8.IsChecked.ToString();
            arr[3] = T_9.IsChecked.ToString();
            arr[4] = T_10.IsChecked.ToString();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "True")
                    answer[i + 6] = 1;
                total += answer[i + 6];
            }
            total += answer[0];

            for (int i = 0; i < An.Length; i++)
                An[i] = answer[i + 1];

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@DateTime.Now.ToString("[AI실증_설문]yyyy-MM-dd") + ".csv", true, Encoding.UTF8))
            {
                //필드 제목
                file.WriteLine("우울척도-단축형 (CESD-10-D)");
                file.WriteLine("문항 번호 , 응답");

                // 필드 값
                for (int i = 1; i < answer.Length; i++)
                {
                    file.WriteLine("{0},{1}", i, answer[i]);
                }
                file.WriteLine("{0},{1}", "Total", total);
            }

            //DB
            main.db.InputQuestionA(An, total);

            return;
        }
    }
}

