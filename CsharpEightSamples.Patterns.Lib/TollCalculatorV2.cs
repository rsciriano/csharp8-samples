using System;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;

namespace CsharpEightSamples.Patterns.Lib
{


    public class TollCalculatorV2 : ITollCalculator
    {
        #region Pattern_CarTaxiOccupancy
        public decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                Car { Passengers: 0 } => 2.00m + 0.50m,
                Car { Passengers: 1 } => 2.0m,
                Car { Passengers: 2 } => 2.0m - 0.50m,
                Car _ => 2.00m - 1.0m,

                Taxi { Fares: 0 } => 3.50m + 1.00m,
                Taxi { Fares: 1 } => 3.50m,
                Taxi { Fares: 2 } => 3.50m - 0.50m,
                Taxi _ => 3.50m - 1.00m,

                Bus b => 5.00m,
                DeliveryTruck t => 10.00m,
                { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null => throw new ArgumentNullException(nameof(vehicle))
            };
        #endregion
    }
}
