namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class FueledVehicle : EngineType
    {
        private readonly eFuelType r_FuelType;

        public FueledVehicle(float i_MaxFuelAmount, eFuelType i_FuelType) : base(i_MaxFuelAmount)
        {
            r_FuelType = i_FuelType;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat(
                "FueledVehicleEngine: {0}, fuel type:  {1}{2}",
                base.ToString(),
                r_FuelType,
                Environment.NewLine);

            return stringBuilder.ToString();
        }

        public void ReFuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if(CountEnergyRightNow + i_FuelToAdd <= CountMaxEnergy) 
            {
                if(i_FuelType.Equals(r_FuelType))
                {
                    CountEnergyRightNow += i_FuelToAdd;
                }
                else
                {
                    throw new ArgumentException(string.Format("Fuel type is incorrect"));
                }
            }
            else
            {
                throw new ValueOutOfRangeException(CountMaxEnergy - CountEnergyRightNow, 0);
            }
        }
    }
}
