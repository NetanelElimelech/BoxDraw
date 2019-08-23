using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BoxDraw
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Box box = new Box();

        public MainPage()
        {
            InitializeComponent();
            //Rectangle front = new Rectangle();
            //Line coverTop = new Line();
            //Box box = new Box();
            DataContext = box;
        }

        private void DrawLine_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush black = new SolidColorBrush(Colors.Black);
            SolidColorBrush red = new SolidColorBrush(Colors.Red);
            SolidColorBrush blue = new SolidColorBrush(Colors.Blue);
            SolidColorBrush green = new SolidColorBrush(Colors.Green);

            Style dotted = new Style();

            double h = DrawCanvas.Height;
            Line coverTop = new Line();
            Canvas.SetLeft(coverTop, 20);
            Canvas.SetTop(coverTop, 20);
            coverTop.X2 = 300;
            coverTop.Y2 = 0;
            coverTop.StrokeThickness = 1;
            coverTop.Stroke = black;
            coverTop.StrokeDashArray = new DoubleCollection() { 1, 0 };
            DrawCanvas.Children.Add(coverTop);

            Line coverLeft = new Line();
            Canvas.SetLeft(coverLeft, 20);
            Canvas.SetTop(coverLeft, 20);
            coverLeft.X2 = 0;
            coverLeft.Y2 = 300;
            coverLeft.StrokeThickness = 1;
            coverLeft.Stroke = blue;
            DrawCanvas.Children.Add(coverLeft);

            Line coverRight = new Line();
            Canvas.SetLeft(coverRight, 320);
            Canvas.SetTop(coverRight, 20);
            coverRight.X2 = 0;
            coverRight.Y2 = 300;
            coverRight.StrokeThickness = 1;
            coverRight.Stroke = red;
            DrawCanvas.Children.Add(coverRight);

            Line coverBottom = new Line();
            Canvas.SetLeft(coverBottom, 20);
            Canvas.SetTop(coverBottom, 320);
            coverBottom.X2 = 300;
            coverBottom.Y2 = 0;
            coverBottom.StrokeThickness = 1;
            coverBottom.Stroke = green;
            DrawCanvas.Children.Add(coverBottom);
        }

        private void RegularLine(int length)
        {
            BoxLine boxLine = new BoxLine();

            if (boxLine is IDrawLine)
            {
                IDrawLine drawLine = boxLine; 
                //boxLine.SetLocation((int)mouseLocation.X, (int)mouseLocation.Y);
                drawLine.SetZero((int)DrawCanvas.Width, (int)DrawCanvas.Height);
                //drawLine.DrawLine(DrawCanvas, 0, 0);
            }
        }

        public void DrawBox_Click(object sender, RoutedEventArgs e)
        {
            box._depthShift = box.CalcDepthShift(box._depth);
            
            Dictionary<string, CornerPoint> CornerPoints = CalcCornerPoints((int)box._height, (int)box._width, (int)box._depthShift, (int)DrawCanvas.Height);
        }

        private Dictionary<string, CornerPoint> CalcCornerPoints(int height, int width, int depthShift, int canvasHeight)
        {
            CornerPoint pointA = new CornerPoint(0, 0, canvasHeight, 0); //front bottom left
            CornerPoint pointB = new CornerPoint(width, 0, canvasHeight, 0); //front bottom right
            CornerPoint pointC = new CornerPoint(0, 0, canvasHeight, height); //front top left
            CornerPoint pointD = new CornerPoint(width, 0, canvasHeight, height); //front top right
            CornerPoint pointE = new CornerPoint(depthShift, 0, canvasHeight, depthShift); //back bottom left
            CornerPoint pointF = new CornerPoint(depthShift, -width, canvasHeight, depthShift); //back bottom right
            CornerPoint pointG = new CornerPoint(depthShift, 0, pointE.Y, height); //back top left
            CornerPoint pointH = new CornerPoint(depthShift, -width, pointF.Y, height); //back top right

            Dictionary<string, CornerPoint> CornerPoints = new Dictionary<string, CornerPoint>()
            {
                { "A", pointA },
                { "B", pointB },
                { "C", pointC },
                { "D", pointD },
                { "E", pointE },
                { "F", pointF },
                { "G", pointG },
                { "H", pointH },
            };

            return CornerPoints;
        }
    }
}
