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
    /// Page11_4.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page11_4 : Window
    {
        MainWindow main = new MainWindow();
        
        public Page11_4()
        {
            InitializeComponent();
            realTime.Text = DateTime.Now.ToString("yyyy-MM-dd tt HH:mm");
        }

        private void kinnect_TouchDown(object sender, TouchEventArgs e)
        {
            
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            ai.Page12 ChangeWInow = new ai.Page12();

            ChangeWInow.Show();
        }
    }
}
