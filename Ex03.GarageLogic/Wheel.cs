namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class Wheel
    {
        private readonly float r_MaxAirPressure;
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public void AddAirPressureToWheel(float i_AirPressureToAdd)
        {
            if(m_CurrentAirPressure + i_AirPressureToAdd <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaxAirPressure - m_CurrentAirPressure, 0);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat(
                "Wheel Manufacturer Name: {0}, Current Air Pressure: {1}, Max Air Pressure: {2}{3}",
                m_ManufacturerName,
                m_CurrentAirPressure, 
                r_MaxAirPressure, 
                Environment.NewLine);

            return stringBuilder.ToString();
        }
    }
}
