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
                Capacity = 100,
                Speed = 70,
                MaxCapacity = 23000,
                Tank = 4000,
            };

            Car audi = new PassengerCar
            {
                Tank = 2300,
                Fuel = 2000,
                FuelConsumption = 10,               
                Speed = 70,
                Passengers = 20,
                MaxPassengers = 20,
            };
            Car bmw = new SportsCar
            {
                Fuel = 300,
                FuelConsumption = 12,
                Speed = 100,
                Tank = 300,
            };

            Console.WriteLine(renault.Type);
            Console.WriteLine(renault.GetRange());
            Console.WriteLine(renault.PredictDistance());
            Console.WriteLine(renault.GetTime(renault.GetRange()));

            Console.WriteLine(audi.Type);
            Console.WriteLine(audi.GetRange());
            Console.WriteLine(audi.PredictDistance());
            Console.WriteLine(audi.GetTime(audi.GetRange()));

            Console.WriteLine(bmw.Type);
            Console.WriteLine(bmw.GetRange());
            Console.WriteLine(bmw.PredictDistance());
            Console.WriteLine(bmw.GetTime(bmw.GetRange()));
        }
    }
}
