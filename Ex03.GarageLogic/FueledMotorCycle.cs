using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FueledMotorCycle:MotorCycle
    {
        private FueledVehicle m_fueledMotorCycle;
        private const float k_MaxFuelAmount = 48;
        private const MyEnum.eFuelType k_FuelType = MyEnum.eFuelType.Octan98;
        public FueledMotorCycle(string i_ModelName, string i_LicenseNumber, string i_EnergyPercentageLeft, string i_WheelManufacturerName)
            : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageLeft, i_WheelManufacturerName)
        {
            m_fueledMotorCycle = new FueledVehicle(k_MaxFuelAmount, k_FuelType);
        }
    }
}
