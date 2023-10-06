using System.Collections.ObjectModel;
using EstateZoningApp.Core.Models.Abstracts;
using Microsoft.UI.Xaml.Controls;

namespace EstateZoningApp.Views.Dialog;

public sealed partial class NewShapeDialog : ContentDialog
{
    public ObservableCollection<SimplePoint> Points { get; set; }

    public NewShapeDialog()
    {
        Points = new()
        {
            new SimplePoint()
        };
        InitializeComponent();
    }

    private void ShapesGrid_BeginningEdit(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridBeginningEditEventArgs e)
    {
        SimplePoint newPoint = new();
        int x = ShapesGrid.SelectedIndex;
        int y = Points.Count;
        if (x + 1 == y)
        {
            Points.Insert(Points.Count, newPoint);
        }
    }
}
