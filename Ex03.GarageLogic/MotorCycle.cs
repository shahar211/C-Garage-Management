namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class MotorCycle : Vehicle
    {
        private eLicenseType m_MotorCycleLicenseType;
        private int m_EngineCapcity;

        public MotorCycle(int i_MotorCycleWheelAmount, float i_MotorCycleMaxAirPressure, EngineType i_EngineType)
            : base(i_MotorCycleMaxAirPressure, i_MotorCycleWheelAmount, i_EngineType)
        {
        }

        public eLicenseType LicenseType
        {
            set
            {
                m_MotorCycleLicenseType = value;
            }
        }

        public int EngineCapcity
        {
            set
            {
                m_EngineCapcity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.AppendFormat(
                "MotorCycle License Type: {0}, Engine Capcity: {1}{2}",
                m_MotorCycleLicenseType.ToString(),
                m_EngineCapcity,
                Environment.NewLine);

            return stringBuilder.ToString();
        }
    }
}
