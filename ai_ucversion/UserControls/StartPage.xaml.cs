using System.Windows;
using System.Windows.Controls;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ai_ucversion.UserControls
{
    /// <summary>
    /// StartPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StartPage : UserControl
    {
        public StartPage()
        {
            InitializeComponent();
        }

        utility.DBClient db = new utility.DBClient();

        private void CB1_IsChecked(object sender, RoutedEventArgs e)
        {
            nextBTN.IsEnabled = true;
            CB1.IsChecked = true;
        }

        private void nextBTN_Click(object sender, RoutedEventArgs e)
        {
            csv(txtBox);

            if (CB1.IsChecked == true && nextBTN.IsEnabled == true && (txtBox.Text.Length == 13 || txtBox.Text.Length == 12))
            {
                //ai.Page1 ChangeWInow = new ai.Page1();
                //ChangeWInow.Show();
            }
        }

        private void txtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            tb.MaxLength = 13;

            if (tb.Text.EndsWith("-"))
            {
                tb.Text = tb.Text.Substring(0, tb.Text.LastIndexOf("-"));
            }

            if (tb.Text.StartsWith("010") || tb.Text.StartsWith("011"))
            {
                if (tb.Text.Length == 4 || tb.Text.Length == 8)
                {
                    tb.Text = tb.Text.Insert(tb.Text.Length - 1, "-");
                }
                else if (tb.Text.Length == 13)
                {
                    tb.Text = Regex.Replace(tb.Text.Replace("-", String.Empty), @"(\d{3})(\d{4})(\d{4})", "$1-$2-$3");
                }
                else if (tb.Text.Length == 12)
                {
                    tb.Text = Regex.Replace(tb.Text.Replace("-", String.Empty), @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
                }
            }

            tb.SelectionStart = tb.Text.Length;
        }

        private void csv(TextBox tb)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@DateTime.Now.ToString("[AI실증_설문]yyyy-MM-dd") + ".csv", true, Encoding.UTF8))
            {
                file.WriteLine("");
                file.WriteLine("UserSN : " + tb.Text);
            }

            //DB
            string num = tb.Text.Replace("-", "");
            db.InputUserInfo(num, DateTime.Now, "3M");
        }

        private void num010_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "010";
        }

        private void num1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "1";
        }

        private void num2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "2";

        }

        private void num3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "3";
        }

        private void num4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "4";
        }

        private void num5_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "5";
        }

        private void num6_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "6";
        }

        private void num7_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "7";
        }

        private void num8_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "8";
        }

        private void num9_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "9";
        }

        private void num0_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text.Length > 12)
                txtBox.Text += "";
            else
                txtBox.Text += "0";
        }

        private void deleteBTN_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (txtBox.Text == "")
                return;
            else
                txtBox.Text = txtBox.Text.Remove(txtBox.Text.Length - 1);
        }
    }
}
