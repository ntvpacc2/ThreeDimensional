using System;

namespace Model
{
    public class Parallelepiped : IThreeDimensional
    {
        private readonly double _a;

        public Parallelepiped(double a)
        {
            if (a > 0)
            {
                _a = a;
            }
            else throw new ArgumentOutOfRangeException("Значение ребра должно быть > 0");
        }

        public string Name => "Пирамида";
        public double Volume => _a * 3;

        public override string ToString()
        {
            return $"{Name}, объём: {Volume}";
        }
    }
}
