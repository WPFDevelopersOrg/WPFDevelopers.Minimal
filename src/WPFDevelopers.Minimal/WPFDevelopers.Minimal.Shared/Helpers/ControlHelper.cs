using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace WPFDevelopers.Minimal.Helpers
{
    public static class ControlHelper
    {
        public static Brush Brush = Application.Current.Resources["BackgroundSolidColorBrush"] as Brush;

        public static Brush WindowForegroundBrush =
            Application.Current.Resources["PrimaryTextSolidColorBrush"] as Brush;

        private static bool _IsCurrentDark;

        public static void OnSubThemeChanged()
        {
            if (!_IsCurrentDark)
            {
                var vBrush = Application.Current.Resources["PrimaryNormalSolidColorBrush"] as Brush;
                Application.Current.Resources["WindowBorderBrushSolidColorBrush"] = vBrush;
            }
        }

        public static void ToggleLightAndDark(bool isDark = false)
        {
            var type = isDark ? ThemeType.Dark : ThemeType.Light;

            var existingResourceDictionary =
                Application.Current.Resources.MergedDictionaries.FirstOrDefault(x => x is Resources) as Resources;
            if (existingResourceDictionary != null)
            {
                existingResourceDictionary.Theme = type;
                if (type == ThemeType.Light)
                {
                    var vBrush = Application.Current.Resources["PrimaryNormalSolidColorBrush"] as Brush;
                    Application.Current.Resources["WindowBorderBrushSolidColorBrush"] = vBrush;
                    WindowForegroundBrush = Application.Current.Resources["PrimaryTextSolidColorBrush"] as Brush;
                    if (Application.Current.Resources["DefaultBackgroundColor"] is Color color)
                        Application.Current.Resources["DefaultBackgroundSolidColorBrush"] = new SolidColorBrush(color);
                }
                else
                {
                    if (Application.Current.Resources["WindowBorderBrushColor"] is Color color)
                    {
                        var colorBrush = new SolidColorBrush(color);
                        Application.Current.Resources["WindowBorderBrushSolidColorBrush"] = colorBrush;
                        Application.Current.Resources["DefaultBackgroundSolidColorBrush"] = colorBrush;
                    }

                    WindowForegroundBrush = Application.Current.Resources["DefaultBackgroundSolidColorBrush"] as Brush;
                }

                Brush = Application.Current.Resources["BackgroundSolidColorBrush"] as Brush;
                //WindowForegroundBrush = Application.Current.Resources["PrimaryTextSolidColorBrush"] as Brush;
                _IsCurrentDark = isDark;
                ThemeRefresh();
            }
        }

        public static void ThemeRefresh()
        {
            var themePath = "pack://application:,,,/WPFDevelopers.Minimal;component/Themes/Theme.xaml";
            var themeResourceDictionary =
                Application.Current.Resources.MergedDictionaries.FirstOrDefault(x =>
                    x.Source != null && x.Source.Equals(themePath));
            if (themeResourceDictionary == null) return;
            Application.Current.Resources.MergedDictionaries.Remove(themeResourceDictionary);
            Application.Current.Resources.MergedDictionaries.Add(themeResourceDictionary);
            OnSubThemeChanged();
        }
    }
}