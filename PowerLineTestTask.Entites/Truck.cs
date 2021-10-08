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

        private const double RANGE_DECREASE = 0.96;
        
        
        public int MaxCapacity { get; init; } = 10000;
        
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
            }
        }


        public override double GetRange()
        {
            return base.GetRange() * Capacity * RANGE_DECREASE;
        }

        public override double PredictDistance()
        {
            return base.PredictDistance() * ((Capacity / 200.0) + 1) * RANGE_DECREASE;
        }
    }
}
