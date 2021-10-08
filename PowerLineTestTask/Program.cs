using System;
using PowerLineTestTask.Entites;

namespace PowerLineTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Car renault = new Truck
            {              
                Fuel = 100,
                FuelConsumption = 10,
                MaxCapacity = 10000,
                Speed = 70,
                Capacity = 2300,
                Tank = 4000,
            };

            Car renault2 = new PassengerCar
            {
                Tank = 2300,
                Fuel = 100,
                FuelConsumption = 10,
                MaxPassengers = 20,
                Speed = 70,
                Passengers = 10,
            };

            Console.WriteLine(renault.Type);
            Console.WriteLine(renault.GetTime(renault.GetRange()));
            Console.WriteLine(renault.GetRange());

            Console.WriteLine(renault2.Type);
            Console.WriteLine(renault2.GetTime(renault2.GetRange()));
            Console.WriteLine(renault2.GetRange());
        }
    }
}
