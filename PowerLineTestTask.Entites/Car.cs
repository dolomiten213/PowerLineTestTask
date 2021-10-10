using System;

namespace PowerLineTestTask.Entites
{
    abstract public class Car
    {
        public abstract CarType Type { get; }

//===============================================================================================//  

        private double _fuelConsumption = 0;
        public double FuelConsumption
        {
            get => _fuelConsumption;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException($"Unacceptable fuel consumption ({value}). Fuel consumption should be non negative");
                }
                else
                {
                    _fuelConsumption = value;
                }
            }
        }
        

        private double _tank = double.MaxValue;
        public double Tank
        {
            get => _tank;
            set
            {
                if (value < _fuel)
                {
                    throw new InvalidOperationException($"Unacceptable tank volume ({value}). Current fuel level is higher");
                }
                else if (value < 0)
                {
                    throw new InvalidOperationException($"Unacceptable tank volume ({value}). Tank volume should be non negative");
                }
                else
                {
                    _tank = value;
                }
            }
        }


        private double _fuel = 0;
        public double Fuel
        {
            get => _fuel;
            set
            {
                if (value > Tank)
                {
                    throw new InvalidOperationException($"Unacceptable fuel quantity({value}). Min = 0 Max = {Tank}");
                }
                if (value < 0)
                {
                    throw new InvalidOperationException($"Unacceptable capacity ({value}). Fuel should be non negative");
                }
                else
                {
                    _fuel = value;
                }
            }
        }
        

        public double Speed { get; set; } = 0;

//===============================================================================================//  
        
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
