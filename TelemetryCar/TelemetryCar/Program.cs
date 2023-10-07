using System;
using TelemetryCar.Data;

public class Program
{
    public static void Main(string[] args)
    {
        using (CarDbContext carDbContext = new CarDbContext())
        {
            var cars_license_plate = carDbContext.CarInfos.Select(car_info => car_info.LicensePlate);

            foreach (var item in cars_license_plate)
            {
                Console.WriteLine(item);
            }
        }
    }
}
