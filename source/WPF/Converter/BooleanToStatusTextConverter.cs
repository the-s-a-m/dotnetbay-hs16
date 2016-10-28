using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF.Converter
{
    class BooleanToStatusTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && (bool)value) return "Open";
            return "Closed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "Open":
                    return true;
                case "Closed":
                    return false;

                default:
                    return Binding.DoNothing;
            }
        }
    }
}
