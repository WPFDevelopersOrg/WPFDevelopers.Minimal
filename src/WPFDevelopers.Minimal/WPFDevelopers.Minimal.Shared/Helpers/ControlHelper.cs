using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace WPFDevelopers.Minimal.Helpers
{
    public static class ControlHelper
    {
        public static Brush Brush = (Brush)Application.Current.TryFindResource("WD.BackgroundSolidColorBrush");

        /// <summary>
        /// PrimaryNormalBrush
        /// </summary>
        public static Brush PrimaryNormalBrush = (Brush)Application.Current.TryFindResource("WD.PrimaryNormalSolidColorBrush");

        public static Brush WindowForegroundBrush =
            (Brush)Application.Current.TryFindResource("WD.PrimaryTextSolidColorBrush");

        private static bool _IsCurrentDark;

        public static void OnSubThemeChanged()
        {
            if (!_IsCurrentDark)
            {
                PrimaryNormalBrush = (Brush)Application.Current.TryFindResource("WD.PrimaryNormalSolidColorBrush");
                Application.Current.Resources["WD.WindowBorderBrushSolidColorBrush"] = PrimaryNormalBrush;
            }
        }

        public static void ToggleLightAndDark(bool isDark = false)
        {
            var type = isDark ? ThemeType.Dark : ThemeType.Light;

            var existingResourceDictionary =
                (Resources)Application.Current.Resources.MergedDictionaries.FirstOrDefault(x => x is Resources);
            if (existingResourceDictionary != null)
            {
                existingResourceDictionary.Theme = type;
                if (type == ThemeType.Light)
                {
                    PrimaryNormalBrush = (Brush)Application.Current.TryFindResource("WD.PrimaryNormalSolidColorBrush");
                    Application.Current.Resources["WD.WindowBorderBrushSolidColorBrush"] = PrimaryNormalBrush;
                    WindowForegroundBrush = (Brush)Application.Current.TryFindResource("WD.PrimaryTextSolidColorBrush");
                    if (Application.Current.TryFindResource("WD.DefaultBackgroundColor") is Color color)
                    {
                        var solidColorBrush = new SolidColorBrush(color);
                        Application.Current.Resources["WD.DefaultBackgroundSolidColorBrush"] = solidColorBrush;

                    }
                }
                else
                {
                    if (Application.Current.TryFindResource("WD.WindowBorderBrushColor") is Color color)
                    {
                        var colorBrush = new SolidColorBrush(color);
                        Application.Current.Resources["WD.WindowBorderBrushSolidColorBrush"] = colorBrush;
                        Application.Current.Resources["WD.DefaultBackgroundSolidColorBrush"] = colorBrush;
                    }

                    WindowForegroundBrush = (Brush)Application.Current.TryFindResource("WD.DefaultBackgroundSolidColorBrush");
                }

                Brush = (Brush)Application.Current.TryFindResource("WD.BackgroundSolidColorBrush");
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
    #region 是否设计时模式
    public class DesignerHelper
    {
        private static bool? _isInDesignMode;

        public static bool IsInDesignMode
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
                    _isInDesignMode = (bool)DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty,
                        typeof(FrameworkElement)).Metadata.DefaultValue;
                }
                return _isInDesignMode.Value;
            }
        }
    }
    #endregion
}