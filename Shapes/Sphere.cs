using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Sphere : Shape3D
    {
        public Sphere(Circle shape) : base(shape) { }

        public override double CalculateVolume()
        {
            Circle circle = (Circle)BaseShape;
            double radius = circle.Radius;

            return (4.0 / 3.0) * Math.PI * (radius * radius * radius);
        }
    }
}
