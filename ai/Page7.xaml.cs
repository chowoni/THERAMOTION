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
    /// Page7.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page7 : Window
    {
        public Page7()
        {
            InitializeComponent();
            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            ai.Page8_1 ChangeWInow = new ai.Page8_1();

            ChangeWInow.Show();
        }
    }
}
