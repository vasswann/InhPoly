using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal abstract class Shape3D
    {
        public Shape BaseShape { get; private set; }

        public Shape3D(Shape baseShaep)
        {
            BaseShape = baseShaep;
        }

        public abstract double CalculateVolume();
    }
}
