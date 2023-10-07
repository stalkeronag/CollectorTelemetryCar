using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Interfaces
{
    public interface ISender
    {
        public void Send(byte[] data);
    }
}
