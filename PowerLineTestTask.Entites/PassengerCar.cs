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

        private const double RANGE_DECREASE = 0.06;


        public int MaxPassengers { get; init; } = int.MaxValue;

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
            var multiplicator = (1 - Passengers * RANGE_DECREASE);
            multiplicator = Math.Max(multiplicator, 0);
            return base.GetRange() * multiplicator;
        }

        public override double PredictDistance()
        {
            var multiplicator = (1 - Passengers * RANGE_DECREASE);
            multiplicator = Math.Max(multiplicator, 0);
            return base.PredictDistance() * multiplicator;
        }
    }
}
