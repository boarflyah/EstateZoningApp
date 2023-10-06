using System.Collections.ObjectModel;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using EstateZoningApp.Core.Models.Abstracts;
using EstateZoningApp.Views.Dialog;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace EstateZoningApp.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    public MainViewModel()
    {
        Elements = new();
        Resources = new();
        Shapes = new();
        ProjectName = "Projekt 1";


        var commandIcon = new SymbolIconSource()
        {
            Symbol = Symbol.NewWindow,
        };
        AddNewShapeCommand = new();
        AddNewShapeCommand.IconSource = commandIcon;
        AddNewShapeCommand.ExecuteRequested += AddNewShapeCommand_ExecuteRequested;
        AddNewShapeCommand.CanExecuteRequested += AddNewShapeCommand_CanExecuteRequested;
    }

    #region Properties

    public double GridWidth
    {
        get; set;
    }

    public double GridHeight
    {
        get; set;
    }

    double DraggedOnX;

    double DraggedOnY;

    [ObservableProperty]
    string _ProjectName;

    double _Scale;
    public double Scale
    {
        get => _Scale;
        set
        {
            if (_Scale != value)
            {
                _Scale = value;
                OnPropertyChanged(nameof(Scale));
                OnPropertyChanged(nameof(DimensionA));
                OnPropertyChanged(nameof(DimensionB));
                if (Elements != null && Elements.Any())
                    foreach (var el in Elements)
                        el.Scale = value;

                if (Shapes != null && Shapes.Any())
                    foreach (var sh in Shapes)
                        sh.Scale = value;
            }
        }
    }

    double _DimensionA;
    public double DimensionA
    {
        get => _DimensionA;
        set
        {
            if (_DimensionA != value)
            {
                _DimensionA = value;
                SetScale();
                OnPropertyChanged(nameof(DimensionA));
            }
        }
    }

    double _DimensionB;
    public double DimensionB
    {
        get => _DimensionB;
        set
        {
            if (_DimensionB != value)
            {
                _DimensionB = value;
                SetScale();
                OnPropertyChanged(nameof(DimensionB));
            }
        }
    }

    SimplePoint _SelectedElement;
    public SimplePoint SelectedElement
    {
        get => _SelectedElement;
        set
        {
            if (_SelectedElement != value)
            {
                _SelectedElement = value;
                OnPropertyChanged(nameof(SelectedElement));
            }    
        }
    }

    public ObservableCollection<SimplePoint> Elements
    {
        get;
        set;
    }

    public ObservableCollection<SimplePoint> Resources
    {
        get;
        set;
    }

    public ObservableCollection<SimpleShape> Shapes
    {
        get;
        set;
    }

    #endregion

    #region Commands

    public XamlUICommand AddNewShapeCommand
    {
        get;
        private set;
    }

    #endregion

    #region Methods

    #region Command methods

    async Task AddNewShape(XamlRoot root)
    {
        try
        {
            NewShapeDialog dialog = new()
            {
                XamlRoot = root
            };
            var dialogResult = await dialog.ShowAsync(ContentDialogPlacement.InPlace);
            if (dialogResult == ContentDialogResult.Primary)
            {
                SimpleShape newShape = new();
                foreach (var sp in dialog.Points.Where(x => x.X > 0 && x.Y > 0))
                    newShape.Points.Add(sp);

                Shapes.Add(newShape);
            }
        }
        catch (Exception e)
        {
        }
    }

    #endregion

    public void LoadElements()
    {
        SimplePoint p1 = new SimplePoint()
        {
            X = 2,
            Y = 5,
            Height = 50,
            Width = 50,
        },
        p2 = new SimplePoint()
        {
            X = 2,
            Y = 10,
            Height = 50,
            Width = 50,
        },
        p3 = new SimplePoint()
        {
            X = 8,
            Y = 7.5,
            Height = 50,
            Width = 50,
        };
        SimplePoint p4 = new SimplePoint()
        {
            X = 8,
            Y = 2,
            Height = 50,
            Width = 50,
        }; 
        SimplePoint p5 = new SimplePoint()
        {
            X = 2,
            Y = 5,
            Height = 50,
            Width = 50,
        };

        SimpleShape Shape = new();

        Shape.Points = new();
        Shape.Points.Add(p1);
        Shape.Points.Add(p2);
        Shape.Points.Add(p3);
        Shape.Points.Add(p4);
        Shape.Points.Add(p5);

        Shapes.Add(Shape);


        SimplePoint p6 = new SimplePoint()
        {
            X = 15,
            Y = 5,
            Height = 50,
            Width = 50,
        };
        SimplePoint p7 = new SimplePoint()
        {
            X = 15,
            Y = 10,
            Height = 50,
            Width = 50,
        };
        SimplePoint p8 = new SimplePoint()
        {
            X = 20,
            Y = 7.5,
            Height = 50,
            Width = 50,
        };
        SimplePoint p9 = new SimplePoint()
        {
            X = 15,
            Y = 5,
            Height = 50,
            Width = 50,
        };

        SimpleShape shape2 = new();
        shape2.Points = new()
        {
            p6,
            p7,
            p8,
            p9
        };

        Shapes.Add(shape2);

        Resources.Add(new SimplePoint()
        {
            Height= 3,
            Width = 3,
            ImagePath = "\\Resources\\tree2.png"
        });

        Resources.Add(new SimplePoint()
        {
            Height = 1,
            Width = 2,
            ImagePath = "\\Resources\\bush1.png"
        });

        //Elements.Add(new SimplePoint()
        //{
        //    X = 2,
        //    Y = 27,
        //    Height = 50,
        //    Width = 50,
        //    ImagePath = "\\Resources\\tree1.png"
        //});
        //Elements.Add(new SimplePoint()
        //{
        //    X = 2,S
        //    Y = 20,
        //    Height = 20,
        //    Width = 20,
        //    ImagePath = "\\Resources\\tree1.png"
        //});
    }

    public void SetScale(double gridWidth, double gridHeight)
    {
        GridHeight = gridHeight;
        GridWidth = gridWidth;
        if (DimensionA != 0 && DimensionB != 0)
        {
            double scaleWidth = gridWidth / DimensionA,
                scaleHeight = gridHeight / DimensionB;

            Scale = Math.Min(scaleWidth, scaleHeight);
        }
        else
            Scale = 0;
    }

    void SetScale()
    {
        if (DimensionA != 0 && DimensionB != 0)
        {
            double scaleWidth = GridWidth / DimensionA,
                scaleHeight = GridHeight / DimensionB;

            Scale = Math.Min(scaleWidth, scaleHeight);
        }
    }

    public void SetDraggedOn(double x, double y)
    {
        DraggedOnX = x;
        DraggedOnY = y;
    }

    public void AddPointToElements(SimplePoint point, double x, double y, double draggedOnX, double draggedOnY)
    {
        //point.X = x / (Scale == 0 ? 1 : Scale);
        //point.Y = y / (Scale == 0 ? 1 : Scale);
        //point.Scale = Scale;
        RelocateElement(point, x, y, draggedOnX, draggedOnY);
        point.Scale = Scale;
        Elements.Add(point);
    }

    public void RelocateElement(SimplePoint point, double x, double y)
    {
        point.X = x / (Scale == 0 ? 1 : Scale);
        point.Y = y / (Scale == 0 ? 1 : Scale);
    }

    public void RelocateElement(SimplePoint point, double x, double y, double draggedOnX, double draggedOnY)
    {
        point.X = (x - draggedOnX) / (Scale == 0 ? 1 : Scale);
        point.Y = (y - draggedOnY) / (Scale == 0 ? 1 : Scale);
    }

    public void ElementTapHandle(SimplePoint point)
    {
        SelectedElement = point;
        point.IsSelected = point.IsSelected ? false : true;
        foreach (var p in Elements.Where(x => x != point))
            p.IsSelected = false;
    }

    #endregion

    #region Events

    private void AddNewShapeCommand_CanExecuteRequested(XamlUICommand sender, CanExecuteRequestedEventArgs args)
    {
        if (DimensionA == 0 || DimensionB== 0)
            args.CanExecute = false;
    }

    private async void AddNewShapeCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
    {
        if (args.Parameter is XamlRoot root)
            await AddNewShape(root);
    }

    #endregion
}
