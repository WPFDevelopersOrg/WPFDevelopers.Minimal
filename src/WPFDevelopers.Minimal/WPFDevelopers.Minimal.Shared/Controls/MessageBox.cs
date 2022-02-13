using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFDevelopers.Minimal.Controls
{
    public static class MessageBox
    {
        public static MessageBoxResult Show(string messageBoxText)
        {
            var msg = new WPFMessageBox(messageBoxText);
            Window win = null;
            if (Application.Current.Windows.Count > 0)
                win = Application.Current.Windows.OfType<Window>().FirstOrDefault(o => o.IsActive);
            if (win != null)
            {
                Grid layer = new Grid() { Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)) };
                UIElement original = win.Content as UIElement;
                win.Content = null;
                Grid container = new Grid();
                container.Children.Add(original);
                container.Children.Add(layer);
                win.Content = container;
                msg.Owner = win;
                msg.ShowDialog();
            }
            else
                msg.Show();
            return msg.Result;
        }
    }
}
