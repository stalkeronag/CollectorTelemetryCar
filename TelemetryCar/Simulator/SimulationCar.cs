using Simulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelemetryCar.Interfaces;

namespace Simulator
{
    public class SimulationCar : ICar
    {
        private ITelemetryCar telemetryCar;

        private ISender sender;

        public SimulationCar(ITelemetryCar telemetryCar, ISender sender)
        {
            this.telemetryCar = telemetryCar;
            this.sender = sender;
        }

        public void Drive()
        {
            telemetryCar.Enable();
        }

        public void Stop()
        {
            telemetryCar.Disable();
        }
    }
}
