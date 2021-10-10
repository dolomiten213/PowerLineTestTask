using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLineTestTask.Entites
{
    public class PassengerCar : Car
    {
        public override CarType Type => CarType.PassengerCar;

//===============================================================================================//

        private const double RANGE_DECREASE = 0.06;

//===============================================================================================//
//
        private int _maxPassengers = int.MaxValue;
        public int MaxPassengers
        {
            get => _maxPassengers;
            set
            {
                if (value < _passengers)
                {
                    throw new InvalidOperationException($"Unacceptable maximum number of passengers ({value}). Current number of passengers is higher");
                }
                else if (value < 0)
                {
                    throw new InvalidOperationException($"Unacceptable maximum passengers number ({value}). Passengers number should be non negative");
                }
                else
                {
                    _maxPassengers = value;
                }
            }
        }


        private int _passengers = 0;
        public int Passengers
        {
            get => _passengers;
            set
            {
                if (value > _maxPassengers)
                {
                    throw new InvalidOperationException($"Unacceptable number of passengers ({value}). Min = 0 Max = {MaxPassengers}");
                }
                else if (value < 0)
                {
                    throw new InvalidOperationException($"Unacceptable number of passengers ({value}). Passengers number should be non negative");
                }
                else
                {
                    _passengers = value;
                }
            }
        }

//===============================================================================================//

        private double CalculateMultiplicator()
        {
            var multiplicator = (1 - Passengers * RANGE_DECREASE);
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
