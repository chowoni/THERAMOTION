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
    /// Page10.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page10 : Window
    {
        public Page10()
        {
            InitializeComponent();
            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.NextPage(4);
            main.CurrentPage = 4;
            main.Show();
        }
    }
}
