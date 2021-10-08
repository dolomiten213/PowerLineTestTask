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

        private const double RANGE_DECREASE = 0.94;
        
        
        public int MaxPassengers { get; init; }

        private int _passengers = 0;
        public int Passengers
        {
            get => _passengers;
            set
            {
                if (value > MaxPassengers)
                {
                    throw new InvalidOperationException($"Unacceptable number of passengers ({value}). Min = 0 Max = {MaxPassengers}");
                }
                else
                {
                    _passengers = value;
                }
            }
        }

        
        public override double GetRange()
        {
            return base.GetRange() * Passengers * RANGE_DECREASE;
        }

        public override double PredictDistance()
        {
            return base.PredictDistance() * Passengers * RANGE_DECREASE;
        }
    }
}
