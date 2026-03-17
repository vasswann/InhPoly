using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    internal class CarEngine : Engine
    {
        public CarEngine() : base(150, FuelType.Diesel)
        {
        }
    }
}
