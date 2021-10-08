using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLineTestTask.Entites
{
    public class Truck : Car
    {
        public override CarType Type => CarType.Truck;

        private const double RANGE_DECREASE = 0.04;


        public int MaxCapacity { get; init; } = int.MaxValue;
        
        private int _capacity = 0;
        public int Capacity
        {
            get => _capacity;
            set
            {
                if (MaxCapacity < _capacity + value)
                {
                    throw new InvalidOperationException($"Unacceptable capacity ({value}). Min = 0 Max = {MaxCapacity}");
                }
                else
                {
                    _capacity = value;
                }
            }
        }


        public override double GetRange()
        {
            var multiplicator = (1 - Math.Ceiling(Capacity / 200.0) * RANGE_DECREASE);
            multiplicator = Math.Max(multiplicator, 0);
            return base.GetRange() * multiplicator;
        }

        public override double PredictDistance()
        {
            var multiplicator = (1 - Math.Ceiling(Capacity / 200.0) * RANGE_DECREASE);
            multiplicator = Math.Max(multiplicator, 0);
            return base.PredictDistance() * multiplicator;
        }
    }
}
