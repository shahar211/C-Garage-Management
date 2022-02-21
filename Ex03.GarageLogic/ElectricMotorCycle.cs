using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorCycle : MotorCycle
    {
        private ElectricVehicle m_ElectricMotorCycle;
        public ElectricMotorCycle(string i_ModelName, string i_LicenseNumber, string i_EnergyPercentageLeft, string i_WheelManufacturerName)
            : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageLeft, i_WheelManufacturerName)
        {
            m_ElectricMotorCycle = new ElectricVehicle(2.3F);
        }
    }
}
