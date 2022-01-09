using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfShocked.Helpers
{
    public class ElementConvert
    {

    }
    public class WidthConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 20;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
