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

//===============================================================================================//
        
        private const double RANGE_DECREASE_MULTIPLICATOR = 0.04;
        private const double RANGE_DECREASE = 200;

//===============================================================================================//    
        
        private int _maxCapacity = int.MaxValue;
        public int MaxCapacity
        {
            get => _maxCapacity;
            set
            {
                if (value < _capacity)
                {
                    throw new InvalidOperationException($"Unacceptable maximum capacity ({value}). Current capacity is higher");
                }
                else if (value < 0)
                {
                    throw new InvalidOperationException($"Unacceptable maximum capacity ({value}). Maximum capacity should be non negative");
                }
                else
                {
                    _maxCapacity = value;
                }
            }
        }
        

        private int _capacity = 0;
        public int Capacity
        {
            get => _capacity;
            set
            {
                if (value > _maxCapacity)
                {
                    throw new InvalidOperationException($"Unacceptable capacity ({value}). Min = 0 Max = {MaxCapacity}");
                }
                else if (value < 0)
                {
                    throw new InvalidOperationException($"Unacceptable capacity ({value}). Capacity should be non negative");
                }
                else
                {
                    _capacity = value;
                }
            }
        }

//===============================================================================================//        

        private double CalculateMultiplicator()
        {
            var multiplicator = (1 - Math.Ceiling(Capacity / RANGE_DECREASE) * RANGE_DECREASE_MULTIPLICATOR);
            multiplicator = Math.Max(multiplicator, 0);
            return multiplicator;
        }
        public override double GetRange()
        {
            return base.GetRange() * CalculateMultiplicator();
        }
        public override double PredictDistance()
        {
            return base.PredictDistance() * CalculateMultiplicator();
        }
    }
}
