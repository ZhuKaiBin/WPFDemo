using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace wpfDemo1.Components;

public partial class DeviceBackGround : UserControl
{
    public ImageSource Source
    {
        get { return (ImageSource)GetValue(SourceProperty); }
        set {  SetValue(SourceProperty, value); }
    }

    public static readonly DependencyProperty SourceProperty =
        DependencyProperty.Register("Source", typeof(ImageSource), typeof(DeviceBackGround), new PropertyMetadata(null));

    public DeviceBackGround()
    {
        InitializeComponent();
        this.SizeChanged += DeviceBackGround_SizeChanged;
    }

    public void DeviceBackGround_SizeChanged(object sender,SizeChangedEventArgs e)
    {
        this.Canvas.Children.Clear();

        double radius = 125.0d;
        for (int i = 0; i < 360; i += 2)
        {
            var x1 = radius + radius * Math.Cos(i * Math.PI / 180);
            var y1 = radius + radius * Math.Sin(i * Math.PI / 180);
            
            var x2 = radius + (radius-10) * Math.Cos(i * Math.PI / 180);
            var y2 = radius + (radius-10) * Math.Sin(i * Math.PI / 180);


            if (i%4==0)
            {
                 x1 = radius + radius * Math.Cos(i * Math.PI / 180);
                 y1 = radius + radius * Math.Sin(i * Math.PI / 180);
            
                 x2 = radius + (radius-5) * Math.Cos(i * Math.PI / 180);
                 y2 = radius + (radius-5) * Math.Sin(i * Math.PI / 180);
            }
            Line line = new Line()
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = Brushes.Orange,
                StrokeThickness = 1
            };
            this.Canvas.Children.Add(line);
        }
    }
}