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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ai_ucversion.UserControls
{
    /// <summary>
    /// Page11_2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page11_2 : UserControl
    {
        MainWindow main;
        public Page11_2(MainWindow mw)
        {
            InitializeComponent();
            main = mw;

            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");
        }

        public event EventHandler NextClick;
        private void next_Click(object sender, RoutedEventArgs e)
        {
            NextClick?.Invoke(sender, e);
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
