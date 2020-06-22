using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace SixConfig.Converters
{
  public class VisibilityFromBooleanConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is bool asBool)
      {
        if (asBool == true)
        {
          return Visibility.Visible;
        }
        else
        {
          return Visibility.Hidden;
        }
      }
      else
      {
        throw new ArgumentException(nameof(value));
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
