using EstateZoningApp.Core.Models;
using EstateZoningApp.Helpers.Converters;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace EstateZoningApp.Helpers;

internal class BindingHelper
{
    #region CanvasLeftBindingPath
    public static readonly DependencyProperty CanvasLeftBindingPathProperty = DependencyProperty.RegisterAttached(
            "CanvasLeftBindingPath", typeof(string), typeof(BindingHelper), new PropertyMetadata(null, BindingPathChanged));

    public static string GetCanvasLeftBindingPath(DependencyObject obj)
    {
        return (string)obj.GetValue(CanvasLeftBindingPathProperty);
    }

    public static void SetCanvasLeftBindingPath(DependencyObject obj, string value)
    {
        obj.SetValue(CanvasLeftBindingPathProperty, value);
    }
    #endregion

    #region CanvasTopBindingPath
    public static readonly DependencyProperty CanvasTopBindingPathProperty = DependencyProperty.RegisterAttached(
            "CanvasTopBindingPath", typeof(string), typeof(BindingHelper), new PropertyMetadata(null, BindingPathChanged));

    public static string GetCanvasTopBindingPath(DependencyObject obj)
    {
        return (string)obj.GetValue(CanvasLeftBindingPathProperty);
    }

    public static void SetCanvasTopBindingPath(DependencyObject obj, string value)
    {
        obj.SetValue(CanvasLeftBindingPathProperty, value);
    }
    #endregion


    // ===================== Change Handler: Creates the actual binding

    private static void BindingPathChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is string source)                                                                // source property (could add DataContext by setting Value="source@datacontext" for example)
        {
            string[] properties = source.Split(';');
            if (properties.Any())
            {

                DependencyProperty target;                                                                  // which property is the target of the binding?
                if (e.Property == CanvasLeftBindingPathProperty) target = Canvas.LeftProperty;
                else if (e.Property == CanvasTopBindingPathProperty) target = Canvas.TopProperty;
                else throw new System.Exception($"BindingHelper: Unknown target ({nameof(e.Property)}");    // don't know this property

                SimplePoint point = null;
                if (obj is ContentPresenter cp && cp.Content is SimplePoint sp)
                    point = sp;

                obj.ClearValue(target);                                                                     // clear previous bindings (and value)
                BindingOperations.SetBinding(obj, target,                                                   // set new binding (and value)
                   new Binding { Path = new PropertyPath(properties[0]), Mode = BindingMode.OneWay,
                   //ConverterParameter = scale,
                   Converter = new PlacementScaleConverter(point)});
            }
        }
    }
}