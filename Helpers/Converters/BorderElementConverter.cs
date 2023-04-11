using EstateZoningApp.Core.Models.Abstracts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace EstateZoningApp.Helpers.Converters;
public class BorderElementConverter : DependencyObject, IValueConverter
{

    public BorderElementConverter()
    {
    }
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return (bool)value ? new Thickness(0.5) : new Thickness(0);
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return true;
    }
}
