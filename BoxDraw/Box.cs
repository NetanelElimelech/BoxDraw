using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxDraw
{
    public class Box : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public double _width;
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public double _depth;
        public double Depth
        {
            get { return _depth; }
            set
            {
                _depth = value;
                OnPropertyChanged(nameof(Depth));
            }
        }

        public double _depthShift { get; set; }

        public double GlassThickness { get; set; }

        public const double GRINDING = 0.2;

        int ZeroPointX = 0;
        int ZeroPointY = 0;

        

        public double CalcDepthShift(double depth)
        {
            return Math.Sqrt((depth * depth) / 2); //Pythagorean theorem
        }
    }
}
