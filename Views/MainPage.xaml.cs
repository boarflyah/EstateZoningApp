using EstateZoningApp.Core.Models.Abstracts;
using EstateZoningApp.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Newtonsoft.Json;
using Windows.Globalization.NumberFormatting;

namespace EstateZoningApp.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    bool isElementRelocating;
    double draggedOnX;
    double draggedOnY;
    SimplePoint dragged;

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
        var formatter = SetNumberBoxNumberFormatter();
        selectedYNumberBox.NumberFormatter = formatter;
        selectedXNumberBox.NumberFormatter = formatter;
    }

    private void Page_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.LoadElements();
    }

    private void BorderGrid_SizeChanged(object sender, Microsoft.UI.Xaml.SizeChangedEventArgs e)
    {
        ViewModel.SetScale(e.NewSize.Width, e.NewSize.Height);
    }

    private void Canvas_DragEnter(object sender, Microsoft.UI.Xaml.DragEventArgs e)
    {
        if (isElementRelocating)
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
        else
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
    }

    private async void Canvas_Drop(object sender, Microsoft.UI.Xaml.DragEventArgs e)
    {
        var position = e.GetPosition(sender as Canvas);
        if (isElementRelocating)
            ViewModel.RelocateElement(ViewModel.SelectedElement, position.X, position.Y, draggedOnX, draggedOnY);
        else
        {
            var json = await e.DataView.GetTextAsync("SimplePointJson");
            SimplePoint dragged = JsonConvert.DeserializeObject<SimplePoint>(json);
            if (dragged != null)
                ViewModel.AddPointToElements(dragged, position.X, position.Y, draggedOnX, draggedOnY);
        }
        isElementRelocating = false;
        e.Handled = true;
    }

    private void GridView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
    {
        e.Data.SetData("SimplePointJson", JsonConvert.SerializeObject(e.Items.FirstOrDefault()));
    }


    private void Canvas_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        if (e.OriginalSource is Image img && img.DataContext is SimplePoint sp)
            ViewModel.ElementTapHandle(sp);

        e.Handled = true;
    }

    private void Image_DragStarting(Microsoft.UI.Xaml.UIElement sender, Microsoft.UI.Xaml.DragStartingEventArgs args)
    {
        if (sender is Image image && image.DataContext is SimplePoint sp)
        {
            var pointerLocation = args.GetPosition(image);
            draggedOnX = pointerLocation.X;
            draggedOnY = pointerLocation.Y;

            ViewModel.ElementTapHandle(sp);
            isElementRelocating = true;
        }
    }

    private DecimalFormatter SetNumberBoxNumberFormatter()
    {
        IncrementNumberRounder rounder = new IncrementNumberRounder();
        rounder.Increment = 0.01;
        rounder.RoundingAlgorithm = RoundingAlgorithm.RoundUp;

        DecimalFormatter formatter = new DecimalFormatter();
        formatter.IntegerDigits = 1;
        formatter.FractionDigits = 2;
        formatter.NumberRounder = rounder;
        return formatter;
    }

    private void Image_DragStarting_1(UIElement sender, DragStartingEventArgs args)
    {
        if (sender is Image image && image.DataContext is SimplePoint sp)
        {
            var pointerLocation = args.GetPosition(image);
            draggedOnX = pointerLocation.X;
            draggedOnY = pointerLocation.Y;
            dragged = sp;
        }
    }

    private void Grid_DragStarting(UIElement sender, DragStartingEventArgs args)
    {
        if (sender is Grid grid && grid.DataContext is SimplePoint sp)
        {
            var pointerLocation = args.GetPosition(grid);
            draggedOnX = pointerLocation.X;
            draggedOnY = pointerLocation.Y;
            dragged = sp;
        }
    }
}
