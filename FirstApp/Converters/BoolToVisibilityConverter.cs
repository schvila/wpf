using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FirstApp.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return DependencyProperty.UnsetValue;

            return (bool)value ? Visibility.Visible : Visibility.Collapsed;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility))
                return null;
            bool? retval;
            switch ((Visibility)value)
            {
                case Visibility.Visible:
                    retval = true;
                    break;
                default:
                    retval = false;
                    break;
            }

            //return DependencyProperty.UnsetValue;

            return retval;
        }
    }
}
