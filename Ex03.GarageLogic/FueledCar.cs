using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FueledCar : Car
    {
        private FueledVehicle m_FueledCar;
        private const float k_MaxFuelAmount=48;
        private const MyEnum.eFuelType k_FuelType = MyEnum.eFuelType.Octan95;
        public FueledCar(string i_ModelName, string i_LicenseNumber, string i_EnergyPercentageLeft, string i_WheelManufacturerName, int i_WheelAmount, float i_MaxAirPressure, MyEnum.eColorType i_CarColor, MyEnum.eCarDoorsAmount i_DoorNumber)
            : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageLeft, i_WheelManufacturerName, i_WheelAmount, i_MaxAirPressure, i_CarColor, i_DoorNumber)
        {
            m_FueledCar = new FueledVehicle(k_MaxFuelAmount, k_FuelType);
        }
    }
}
