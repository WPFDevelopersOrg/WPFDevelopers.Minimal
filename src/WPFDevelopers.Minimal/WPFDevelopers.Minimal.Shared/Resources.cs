using System;
using System.Windows;
using WPFDevelopers.Minimal.Helpers;

namespace WPFDevelopers.Minimal
{
    public class Resources : ResourceDictionary
    {
        public static event ThemeChangedEvent ThemeChanged;
        public ThemeType Theme
        {
            set => InitializeTheme(value);
        }

        protected void InitializeTheme(ThemeType themeType)
        {
            MergedDictionaries.Clear();
            var path = GetResourceUri(GetThemeResourceName(themeType));
            MergedDictionaries.Add(new ResourceDictionary { Source = path });
            ThemeChanged?.Invoke(themeType);
        }

        protected Uri GetResourceUri(string path)
        {
            return new Uri($"pack://application:,,,/WPFDevelopers.Minimal;component/Themes/Basic/{path}.xaml");
        }

        protected string GetThemeResourceName(ThemeType themeType)
        {
            return themeType == ThemeType.Light ? "Light.Color" : "Dark.Color";
        }
    }
    public delegate void ThemeChangedEvent(ThemeType currentTheme);
}