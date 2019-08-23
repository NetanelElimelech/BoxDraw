using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace BoxDraw
{
    interface IDrawLine
    {
        void SetZero(int xCoord, int yCoord);
        void DrawLine(Canvas canvas, int top, int left, int Y2, int X2);
    }
}
