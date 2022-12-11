using System;

namespace Model
{
    public class Ball : IThreeDimensional
    {
        private readonly double _r;
        
        public Ball(double r)
        {
            if (r > 0)
                _r = r;
            else throw new ArgumentOutOfRangeException("Значение радиуса должно быть > 0");
        }

        public string Name => "Шар";
        public double Volume => 4 * Math.PI * _r * _r * _r / 3;

        public override string ToString()
        {
            return $"{Name}, объём: {Volume}";
        }
    }
}
