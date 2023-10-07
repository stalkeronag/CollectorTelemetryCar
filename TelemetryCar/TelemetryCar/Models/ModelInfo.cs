using System;
using System.Collections.Generic;

namespace TelemetryCar.Models;

public partial class ModelInfo
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CarInfo> CarInfos { get; set; } = new List<CarInfo>();
}
