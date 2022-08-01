using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFDevelopers.Minimal.Controls
{
    public static partial class Loading
    {
        /// <summary>
        /// Is Loading Run 
        /// </summary>
        public static bool IsLoadingRun;
        static Window win = null;
        public static void Show()
        {
            if (Application.Current.Windows.Count > 0)
                win = Application.Current.Windows.OfType<Window>().FirstOrDefault(o => o.IsActive);
            if (win != null)
            {
                var layer = new Grid();
                layer.Children.Add(new Rectangle { Fill = Brushes.White, Opacity = .7 });
                var ladoing = new WPFLoading();
                layer.Children.Add(ladoing);
                UIElement original = win.Content as UIElement;
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
            if (win == null) return;
            var grid = win.Content as Grid;
            UIElement original = VisualTreeHelper.GetChild(grid, 0) as UIElement;
            grid.Children.Remove(original);
            win.Content = original;
            IsLoadingRun = false;
        }

    }
}
