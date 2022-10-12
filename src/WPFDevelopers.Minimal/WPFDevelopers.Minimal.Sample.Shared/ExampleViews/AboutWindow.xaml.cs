using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDevelopers.Minimal.Sample.ExampleViews
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class AboutWindow
    {
        public AboutWindow()
        {
            InitializeComponent();
           
        }
        private void GithubHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void GiteeHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void QQHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            var uri = new Uri(@"https://qm.qq.com/cgi-bin/qm/qr?k=f2zl3nvoetItho8kGfe1eys0jDkqvvcL&jump_from=webapi");
            Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
            e.Handled = true;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
