using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryCar.Interfaces
{
    internal interface ISender
    {
        public void Send(byte[] data);
    }
}
