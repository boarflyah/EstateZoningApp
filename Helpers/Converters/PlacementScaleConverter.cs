using EstateZoningApp.Core.Models.Abstracts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace EstateZoningApp.Helpers.Converters;

public class PlacementScaleConverter : DependencyObject, IValueConverter
{
    public SimplePoint Point
    {
        get => (SimplePoint)GetValue(PointProperty);
        set => SetValue(PointProperty, value);
    }

    public static readonly DependencyProperty PointProperty =
        DependencyProperty.Register("Point",
                                    typeof(SimplePoint),
                                    typeof(PlacementScaleConverter),
                                    new PropertyMetadata(null));

    public PlacementScaleConverter(SimplePoint point)
    {
        Point = point;
    }

    public PlacementScaleConverter()
    {
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return (double)value * (Point?.Scale ?? 1);
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return (double)value / (Point?.Scale ?? 0);
    }
}
