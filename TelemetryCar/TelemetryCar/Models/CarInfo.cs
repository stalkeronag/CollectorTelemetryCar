using System;
using System.Collections.Generic;

namespace TelemetryCar.Models;

public partial class CarInfo
{
    public string? LicensePlate { get; set; }

    public long Id { get; set; }

    public long ModelId { get; set; }

    public int? AmountCharge { get; set; }

    public int? TemperatureOut { get; set; }

    public int? TemperatureInside { get; set; }

    public int? TemperatureEngine { get; set; }

    public int? AverageSpeed { get; set; }

    public long? Mileage { get; set; }

    public bool? Busy { get; set; }

    public virtual ModelInfo Model { get; set; } = null!;
}
