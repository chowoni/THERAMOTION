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
    /// Page4_7.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page4_7 : Window
    {
        bool query = false, All = false;
        String[] tmp = new String[5];
        int[] answer = new int[8]; //index 0 : 총 합, 1~8 : 개별 문항에 대한 점수

        MainWindow main = new MainWindow();

        public Page4_7(int[] data)
        {
            InitializeComponent();
            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");

            for (int i = 0; i < data.Length; i++)
                answer[i] = data[i];
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            answer[0] -= answer[6];

            ai_ucversion.Page4_6 ChangeWInow = new ai_ucversion.Page4_6(answer);

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
                ai_ucversion.Page5_1 ChangeWInow = new ai_ucversion.Page5_1(null); ;

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


            int[] An = new int[7];

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
                    answer[7] = 0;
                    answer[0] += answer[7];
                    break;
                case 2:
                    answer[7] = 1;
                    answer[0] += answer[7];
                    break;
                case 3:
                    answer[7] = 2;
                    answer[0] += answer[7];
                    break;
                case 4:
                    answer[7] = 3;
                    answer[0] += answer[7];
                    break;
            }

            for (int i = 0; i < An.Length; i++)
            {
                An[i] = answer[i + 1];

            }


            //CSV
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@DateTime.Now.ToString("[AI실증_설문]yyyy-MM-dd") + ".csv", true, Encoding.UTF8))
            {
                //필드 제목
                file.WriteLine("");
                file.WriteLine("일반화된 불안장애 척도-7 (GAD-7)");
                file.WriteLine("문항 번호 , 응답");

                // 필드 값
                for (int i = 1; i < answer.Length; i++)
                {
                    file.WriteLine("{0},{1}", i, answer[i]);
                }
                file.WriteLine("{0},{1}", "Total", answer[0]);
            }

            main.db.InputQuestionA(An, total);
        }
    }
}
