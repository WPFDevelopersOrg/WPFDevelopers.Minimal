using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WPFDevelopers.Minimal.Helpers;

namespace WPFDevelopers.Minimal.Controls
{
    public static class Loading
    {
        /// <summary>
        /// End your current task after loading the control and exiting
        /// </summary>
        public static event EventHandler<EventArgs> LoadingQuitEvent;
        /// <summary>
        /// Is Loading Run
        /// </summary>
        public static bool IsLoadingRun;

        private static Window win;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showOff">Whether to enable the close button</param>
        public static void Show(bool showOff = false)
        {
            if (Application.Current.Windows.Count > 0)
                win = Application.Current.Windows.OfType<Window>().FirstOrDefault(o => o.IsActive);
            if (win != null)
            {
                var layer = new Grid();
                layer.Children.Add(new Rectangle { Fill = ControlHelper.Brush, Opacity = .7 });
                var ladoing = new WPFLoading();
                layer.Children.Add(ladoing);
                if (showOff)
                {
                    var btnClose = new Button()
                    {
                        Style = Application.Current.FindResource("PathButton") as Style,
                        Content = new Path
                        {
                            Data = Application.Current.FindResource("PathMetroWindowClose") as Geometry,
                            Stretch = Stretch.Fill,
                            Width = 10,
                            Height = 10,
                            Fill = Application.Current.Resources["PrimaryTextSolidColorBrush"] as Brush,//ControlHelper.WindowForegroundBrush,
                        }
                    };
                    btnClose.Click += delegate 
                    {
                        Close();
                        LoadingQuitEvent?.Invoke(null, EventArgs.Empty);
                    };
                    layer.Children.Add(btnClose);
                }
                var original = win.Content as UIElement;
                win.Content = null;
                var container = new Grid();
                container.Children.Add(original);
                container.Children.Add(layer);
                win.Content = container;
                IsLoadingRun = true;
            }
        }

        public static void Close()
        {
            if (!IsLoadingRun) return;
            if (win == null) return;
            var grid = win.Content as Grid;
            if (grid == null) return;
            var original = VisualTreeHelper.GetChild(grid, 0) as UIElement;
            grid.Children.Remove(original);
            win.Content = original;
            IsLoadingRun = false;
        }
    }
}