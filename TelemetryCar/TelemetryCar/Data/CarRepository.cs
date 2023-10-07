using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelemetryCar.Dto;
using TelemetryCar.Models;

namespace TelemetryCar.Data
{
    public class CarRepository
    {
        private readonly CarDbContext carDbContext;

        public CarRepository(CarDbContext carDbContext)
        {
            this.carDbContext = carDbContext;
        }

        public async void AddCar(AddCarDto addCarDto)
        {
            CarInfo carInfo = new CarInfo()
            {
                LicensePlate = addCarDto.LicensePlate,
                Id = addCarDto.Id,
                Mileage = addCarDto.Mileage,
                TemperatureEngine = addCarDto.TemperatureEngine,
                TemperatureInside = addCarDto.TemperatureInside,
                TemperatureOut = addCarDto.TemperatureOut,
                Busy = addCarDto.Busy,
                AmountCharge = addCarDto.AmountCharge,
                AverageSpeed = addCarDto.AverageSpeed,
                ModelId = addCarDto.ModelId,
            };

            await carDbContext.AddAsync(carInfo);
            await carDbContext.SaveChangesAsync();
        }
    }
}
