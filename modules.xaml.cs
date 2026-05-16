using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Automation.Peers;
namespace WindowsRecoveryy
{
    /// <summary>
    /// Логика взаимодействия для modules.xaml
    /// </summary>
    public partial class modules : Window
    {
        public modules()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("modules/necocmd.exe");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow windoww = new MainWindow();
            windoww.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            hidden windoww = new hidden();
            windoww.Show();
            this.Close();
        }
    }
}
