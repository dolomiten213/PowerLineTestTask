
namespace PowerLineTestTask.Entites
{
    abstract public class Car
    {
        public abstract CarType Type { get; }
        public double FuelConsumption { get; init; } = 0;
        public double Tank { get; init; } = 0;
        private double _fuel;
        public double Fuel
        {
            get => _fuel;
            set
            {
                if (value > Tank)
                {
                    throw new System.InvalidOperationException($"Unacceptable fuel quantity({value}). Min = 0 Max = {Tank}");
                }
            }
        }
        public double Speed { get; set; } = 0;

        public virtual double GetRange()
        {
            return Tank / FuelConsumption;
        }
        public virtual double PredictDistance()
        {
            return Fuel / FuelConsumption;
        }
        public virtual double GetTime(double distance)
        {
            return distance / Speed;
        }
    }
}
