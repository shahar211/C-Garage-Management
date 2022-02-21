namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class ElectricVehicle : EngineType
    {
        public ElectricVehicle(float i_MaxBatteryHours)
            : base(i_MaxBatteryHours)
        {
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat(
                "ElectricVehicleEngine: {0}{1}",
                base.ToString(),
                Environment.NewLine);

            return stringBuilder.ToString();
        }

        public void ReChargeBattery(float i_BattryHoursToCharge)
        {
            if(CountEnergyRightNow + i_BattryHoursToCharge <= CountMaxEnergy)
            {
                CountEnergyRightNow += i_BattryHoursToCharge; 
            }
            else
            {
                throw new ValueOutOfRangeException(CountMaxEnergy - CountEnergyRightNow, 0);
            }
        }
    }
}