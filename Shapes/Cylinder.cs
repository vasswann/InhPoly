using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Cylinder : Shape3D
    {
        public double Height { get; set; }

        public Cylinder(Circle shape, double height) : base(shape)
        {
            Height = height;
        }
        public override double CalculateVolume()
        {

            return BaseShape.CalculateArea() * Height;
        }
    }
}
