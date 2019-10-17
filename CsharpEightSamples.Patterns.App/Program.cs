using System;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using CsharpEightSamples.Patterns.Lib;
using LiveryRegistration;


namespace CsharpEightSamples.Patterns.App
{
    static class Program
    {
        static void Main()
        {
            TestVehicleType();
            TestOccupancy("Pattern_CarTaxiOccupancy");
            TestOccupancy("Pattern_BusOccupancy");
            TestOccupancy("Pattern_DeliveryTruckWeight");
            TestOccupancy("Pattern_ChainedPatterns");
            PeakPricing();
        }

        static void TestVehicleType()
        {
            #region Patterns_VehicleType
            var tollCalc = new TollCalculatorV1();

            var car = new Car();
            var taxi = new Taxi();
            var bus = new Bus();
            var truck = new DeliveryTruck();

            Console.WriteLine($"The toll for a car is {tollCalc.CalculateToll(car)}");
            Console.WriteLine($"The toll for a taxi is {tollCalc.CalculateToll(taxi)}");
            Console.WriteLine($"The toll for a bus is {tollCalc.CalculateToll(bus)}");
            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(truck)}");

            try
            {
                tollCalc.CalculateToll("this will fail");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Caught an argument exception when using the wrong type");
            }
            try
            {
                tollCalc.CalculateToll(null);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Caught an argument exception when using null");
            }
            #endregion
        }

        static void TestOccupancy(string regionName)
        {

            ITollCalculator tollCalc = regionName switch
            {
                "Pattern_CarTaxiOccupancy" => new TollCalculatorV2() as ITollCalculator,
                "Pattern_BusOccupancy" => new TollCalculatorV3() as ITollCalculator,
                "Pattern_DeliveryTruckWeight" => new TollCalculatorV4() as ITollCalculator,
                "Pattern_ChainedPatterns" => new TollCalculatorV5() as ITollCalculator,
                _ => new TollCalculatorV1() as ITollCalculator,
            };

            var soloDriver = new Car();
            var twoRideShare = new Car { Passengers = 1 };
            var threeRideShare = new Car { Passengers = 2 };
            var fullVan = new Car { Passengers = 5 };
            var emptyTaxi = new Taxi();
            var singleFare = new Taxi { Fares = 1 };
            var doubleFare = new Taxi { Fares = 2 };
            var fullVanPool = new Taxi { Fares = 5 };
            var lowOccupantBus = new Bus { Capacity = 90, Riders = 15 };
            var normalBus = new Bus { Capacity = 90, Riders = 75 };
            var fullBus = new Bus { Capacity = 90, Riders = 85 };

            var heavyTruck = new DeliveryTruck { GrossWeightClass = 7500 };
            var truck = new DeliveryTruck { GrossWeightClass = 4000 };
            var lightTruck = new DeliveryTruck { GrossWeightClass = 2500 };

            Console.WriteLine($"The toll for a solo driver is {tollCalc.CalculateToll(soloDriver)}");
            Console.WriteLine($"The toll for a two ride share is {tollCalc.CalculateToll(twoRideShare)}");
            Console.WriteLine($"The toll for a three ride share is {tollCalc.CalculateToll(threeRideShare)}");
            Console.WriteLine($"The toll for a fullVan is {tollCalc.CalculateToll(fullVan)}");

            Console.WriteLine($"The toll for an empty taxi is {tollCalc.CalculateToll(emptyTaxi)}");
            Console.WriteLine($"The toll for a single fare taxi is {tollCalc.CalculateToll(singleFare)}");
            Console.WriteLine($"The toll for a double fare taxi is {tollCalc.CalculateToll(doubleFare)}");
            Console.WriteLine($"The toll for a full van taxi is {tollCalc.CalculateToll(fullVanPool)}");

            Console.WriteLine($"The toll for a low-occupant bus is {tollCalc.CalculateToll(lowOccupantBus)}");
            Console.WriteLine($"The toll for a regular bus is {tollCalc.CalculateToll(normalBus)}");
            Console.WriteLine($"The toll for a bus is {tollCalc.CalculateToll(fullBus)}");

            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(heavyTruck)}");
            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(truck)}");
            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(lightTruck)}");

            try
            {
                tollCalc.CalculateToll("this will fail");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Caught an argument exception when using the wrong type");
            }
            try
            {
                tollCalc.CalculateToll(null!);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Caught an argument exception when using null");
            }
        }

        static void PeakPricing()
        {
            var tollCalc = new TollCalculatorV5();

            var testTimes = new DateTime[]
            {
                new DateTime(2019, 3, 4, 8, 0, 0), // morning rush
                new DateTime(2019, 3, 6, 11, 30, 0), // daytime
                new DateTime(2019, 3, 7, 17, 15, 0), // evening rush
                new DateTime(2019, 3, 14, 03, 30, 0), // overnight

                new DateTime(2019, 3, 16, 8, 30, 0), // weekend morning rush
                new DateTime(2019, 3, 17, 14, 30, 0), // weekend daytime
                new DateTime(2019, 3, 17, 18, 05, 0), // weekend evening rush
                new DateTime(2019, 3, 16, 01, 30, 0), // weekend overnight
            };

            foreach (var time in testTimes)
            {
                Console.WriteLine($"Inbound premium at {time} is {tollCalc.PeakTimePremium(time, true)}");
                Console.WriteLine($"Outbound premium at {time} is {tollCalc.PeakTimePremium(time, false)}");
            }
        }
    }
}
