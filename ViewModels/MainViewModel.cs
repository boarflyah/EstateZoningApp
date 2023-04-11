using System.Collections.ObjectModel;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using EstateZoningApp.Core.Models.Abstracts;

namespace EstateZoningApp.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    public MainViewModel()
    {
        Elements = new();
        Resources = new();
        Shapes = new();
        ProjectName = "Projekt 1";
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



    #endregion

    #region Methods

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

        Shapes.Add(Shape);


        Resources.Add(new SimplePoint()
        {
            Height= 50,
            Width = 50,
            ImagePath = "\\Resources\\tree1.png"
        });

        Resources.Add(new SimplePoint()
        {
            Height = 50,
            Width = 50,
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

    public void AddPointToElements(SimplePoint point, double x, double y)
    {
        //point.X = x / (Scale == 0 ? 1 : Scale);
        //point.Y = y / (Scale == 0 ? 1 : Scale);
        //point.Scale = Scale;
        RelocateElement(point, x, y);
        point.Scale = Scale;
        Elements.Add(point);
    }

    public void RelocateElement(SimplePoint point, double x, double y)
    {
        point.X = x / (Scale == 0 ? 1 : Scale);
        point.Y = y / (Scale == 0 ? 1 : Scale);
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



    #endregion
}
