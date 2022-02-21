namespace Ex03.GarageLogic
{
    using System.Text;

    public abstract class EngineType
    {
        private readonly float r_CountMaxEnergy;
        private float m_CountEnergyRightNow;
        private float m_EnergyPercentageLeft;

        public EngineType(float i_CountMaxEnergy)
        {
            r_CountMaxEnergy = i_CountMaxEnergy;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat(
                "Energy Right Now: {0}, Max Energy: {1},Energy Percentage Left: {2}",
                m_CountEnergyRightNow,
                r_CountMaxEnergy,
                m_EnergyPercentageLeft);

            return stringBuilder.ToString();
        }

        public float CountEnergyRightNow
        {
            get
            {
                return m_CountEnergyRightNow;
            }

            set
            {
                m_CountEnergyRightNow = value;
                m_EnergyPercentageLeft = (m_CountEnergyRightNow / r_CountMaxEnergy) * 100;
            }
        }

        public float CountMaxEnergy
        {
            get
            {
                return r_CountMaxEnergy;
            }
        }
    }
}
