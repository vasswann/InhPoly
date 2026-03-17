using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }
        public Motorcycle(string make, string model, bool hasSideCar) : base(make, model, new MotorcycleEngine())
        {
            this.HasSidecar = hasSideCar;
        }

        protected override void Accelerate()
        {
            string message = $"{Make} {Model} speed: ";
            double fuelMod = EngineType.FuelType switch
            {
                FuelType.Unleaded => 1.5D,
                FuelType.Leaded => 1.2D,
                FuelType.Diesel => 1.8D,
                _ => throw new InvalidOperationException($"Unexpected value: {EngineType.FuelType}")
            };
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{message}{((EngineType.Horsepower* fuelMod) * Math.Exp(Math.Sqrt(i)) / 2) * (HasSidecar ? 0.8 : 1.0)}mph");
            }
        }
    }
}
