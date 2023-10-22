using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace EstateZoningApp.Helpers.Converters;
public class BorderScaleConverter : DependencyObject, IValueConverter
{
    public double Scale
    {
        get => (double)GetValue(ScaleProperty);
        set => SetValue(ScaleProperty, value);
    }

    public static readonly DependencyProperty ScaleProperty =
        DependencyProperty.Register("Scale",
                                    typeof(double),
                                    typeof(BorderScaleConverter),
                                    new PropertyMetadata(null));

    public BorderScaleConverter()
    {
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return (double)value * Scale;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return value;
    }
}
