using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryCar.Interfaces
{
    internal interface IReader
    {
        public byte[] Read();

        public int available { get; set; }
    }
}
