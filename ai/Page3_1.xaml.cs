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



namespace ai
{
    /// <summary>
    /// Page3_1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page3_1 : Window
    {
        bool query1 = false, query2 = false, query3 = false, query4 = false, query5 = false, All = false;
        String[] arr = new String[5];
        int i = 0;
        bool ch1, ch2, ch3, ch4, ch5 = false;

        static int[] answer = new int[6];
        public Page3_1()
        {
            InitializeComponent();
            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");
            a1.Source = new BitmapImage(new Uri(@"/res/border.png", UriKind.Relative));
        }
        private void Q_1_Checked(object sender, RoutedEventArgs e)
        {
            if (T_1.IsChecked == false)
            {
                C1T.Visibility = Visibility.Visible;
                C1T.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C1F.Visibility = Visibility.Collapsed;
            }
            else
            {
                C1F.Visibility = Visibility.Visible;
                C1F.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C1T.Visibility = Visibility.Collapsed;
            }

            a1.Visibility = Visibility.Collapsed;
            a2.Source = new BitmapImage(new Uri(@"/res/border.png", UriKind.Relative));

            gL1.Source = new BitmapImage(new Uri(@"/res/L.png", UriKind.Relative));
            gF1.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));
            gT1.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));

            if ((gL1.Source != null) && ch1 == false)
            {
                i++;

                cnt.Text = "0" + i.ToString();
                ch1 = true;
            }
        }

        private void Q_2_Checked(object sender, RoutedEventArgs e)
        {
            if (T_2.IsChecked == true)
            {
                C2T.Visibility = Visibility.Visible;
                C2T.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C2F.Visibility = Visibility.Collapsed;
            }
            else
            {
                C2F.Visibility = Visibility.Visible;
                C2F.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C2T.Visibility = Visibility.Collapsed;
            }

            a2.Visibility = Visibility.Collapsed;
            a3.Source = new BitmapImage(new Uri(@"/res/border.png", UriKind.Relative));

            gL2.Source = new BitmapImage(new Uri(@"/res/L.png", UriKind.Relative));
            gF2.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));
            gT2.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));

            if (gL2.Source != null && ch2 == false)
            {
                i++;
                cnt.Text = "0" + i.ToString();
                ch2 = true;
            }
        }

        private void Q_3_Checked(object sender, RoutedEventArgs e)
        {
            if (T_3.IsChecked == true)
            {
                C3T.Visibility = Visibility.Visible;
                C3T.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C3F.Visibility = Visibility.Collapsed;
            }
            else
            {
                C3F.Visibility = Visibility.Visible;
                C3F.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C3T.Visibility = Visibility.Collapsed;
            }

            a3.Visibility = Visibility.Collapsed;
            a4.Source = new BitmapImage(new Uri(@"/res/border.png", UriKind.Relative));

            gL3.Source = new BitmapImage(new Uri(@"/res/L.png", UriKind.Relative));
            gF3.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));
            gT3.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));

            if (gL3.Source != null && ch3 == false)
            {
                i++;
                cnt.Text = "0" + i.ToString();
                ch3 = true;
            }
        }

        private void Q_4_Checked(object sender, RoutedEventArgs e)
        {
            if (T_4.IsChecked == true)
            {
                C4T.Visibility = Visibility.Visible;
                C4T.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C4F.Visibility = Visibility.Collapsed;
            }
            else
            {
                C4F.Visibility = Visibility.Visible;
                C4F.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C4T.Visibility = Visibility.Collapsed;
            }

            a4.Visibility = Visibility.Collapsed;
            a5.Source = new BitmapImage(new Uri(@"/res/border.png", UriKind.Relative));

            gL4.Source = new BitmapImage(new Uri(@"/res/L.png", UriKind.Relative));
            gF4.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));
            gT4.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));

            if (gL4.Source != null && ch4 == false)
            {
                i++;
                cnt.Text = "0" + i.ToString();
                ch4 = true;
            }
        }
        private void Q_5_Checked(object sender, RoutedEventArgs e)
        {
            if (T_5.IsChecked == true)
            {
                C5T.Visibility = Visibility.Visible;
                C5T.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C5F.Visibility = Visibility.Collapsed;
            }
            else
            {
                C5F.Visibility = Visibility.Visible;
                C5F.Source = new BitmapImage(new Uri(@"/res/checked.png", UriKind.Relative));
                C5T.Visibility = Visibility.Collapsed;
            }

            a5.Visibility = Visibility.Collapsed;

            gL5.Source = new BitmapImage(new Uri(@"/res/L.png", UriKind.Relative));
            gF5.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));
            gT5.Source = new BitmapImage(new Uri(@"/res/S.png", UriKind.Relative));

            if (gL5.Source != null && ch5 == false)
            {
                i++;
                cnt.Text = "0" + i.ToString();
                ch5 = true;
            }
        }
        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (query1 && query2 && query3 && query4 && query5)
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
                ai.Page3_2 ChangeWInow = new ai.Page3_2(answer);

                ChangeWInow.Show();
            }
        }

        private void QnA(object sender, RoutedEventArgs e)
        {
            query1 = (F_1.IsChecked == true) || (T_1.IsChecked == true);

            query2 = (F_2.IsChecked == true) || (T_2.IsChecked == true);

            query3 = (F_3.IsChecked == true) || (T_3.IsChecked == true);

            query4 = (F_4.IsChecked == true) || (T_4.IsChecked == true);

            query5 = (F_5.IsChecked == true) || (T_5.IsChecked == true);
        }
        private void btnTOscore()
        {
            int total = 0;

            arr[0] = T_1.IsChecked.ToString();
            arr[1] = T_2.IsChecked.ToString();
            arr[2] = T_3.IsChecked.ToString();
            arr[3] = T_4.IsChecked.ToString();
            arr[4] = T_5.IsChecked.ToString();

            for (int i = 0; i < 5; i++)
            {
                if (arr[i] == "True")
                    answer[i + 1] = 1;

                total += answer[i + 1];
                answer[0] = total;
            }
            
            return;
        }
    }
}
