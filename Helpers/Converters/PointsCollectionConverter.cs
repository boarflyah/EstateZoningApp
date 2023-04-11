using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System.Collections.ObjectModel;
using EstateZoningApp.Core.Models.Abstracts;

namespace EstateZoningApp.Helpers.Converters;
public class PointsCollectionConverter : DependencyObject, IValueConverter
{
    public double Scale
    {
        get => (double)GetValue(ScaleProperty);
        set => SetValue(ScaleProperty, value);
    }

    public static readonly DependencyProperty ScaleProperty =
        DependencyProperty.Register("Scale",
                                    typeof(double),
                                    typeof(PointsCollectionConverter),
                                    new PropertyMetadata(null));

    public PointsCollectionConverter()
    {
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        PointCollection pc = new PointCollection();
        if (value is ObservableCollection<SimplePoint> points)
        {
            foreach (var sp in points)
                pc.Add(new Windows.Foundation.Point(sp.X * Scale, sp.Y * Scale));
        }
        return pc;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return value;
    }
}
