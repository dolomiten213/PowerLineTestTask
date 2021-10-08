using System;
using PowerLineTestTask.Entites;

namespace PowerLineTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Car renault = new PassengerCar
            {
                Fuel = 100,
                FuelConsumption = 10,
                MaxPassengers = 6,
                Speed = 70,
                Passengers = 3,
                Tank = 400,
            };

            Console.WriteLine(renault.Type);
            Console.WriteLine(renault.GetTime(renault.GetRange()));
        }
    }
}
