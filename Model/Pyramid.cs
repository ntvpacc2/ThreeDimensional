using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pyramid : IThreeDimensional
    {
        private readonly double _h;
        private readonly double _s;

        public Pyramid(double s, double h)
        {
            if (s > 0 && h > 0)
            {
                _s = s;
                _h = h;
            }
            else throw new ArgumentOutOfRangeException("Значение площади основания и высоты должно быть > 0");
        }

        public string Name => "Пирамида";
        public double Volume => _s*_h / 3;

        public override string ToString()
        {
            return $"{Name}, объём: {Volume}";
        }
    }
}
