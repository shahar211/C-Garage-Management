namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Vehicle
    {
        private readonly int r_AmountWheels;
        private readonly List<Wheel> r_WheelsCollection;
        private string m_ModelName;
        private string m_LicenseNumber;
        private EngineType m_EngineType;

        public Vehicle(float i_MaxAirPressure, int i_AmountWheels, EngineType i_EngineType)
        {
            r_AmountWheels = i_AmountWheels;
            m_EngineType = i_EngineType;
            r_WheelsCollection = new List<Wheel>();

            for(int i = 0; i < r_AmountWheels; i++)
            {
                r_WheelsCollection.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public void Init(string i_ModelName, string i_LicenseNumber, List<float> i_WheelsAirPressure, string i_WheelModelName)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;

            foreach(Wheel wheel in r_WheelsCollection)
            {
                wheel.CurrentAirPressure = i_WheelsAirPressure.ElementAt(r_WheelsCollection.IndexOf(wheel));
                wheel.ManufacturerName = i_WheelModelName;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat(
                "Model name: {0}{1}License Number: {2}{3}Number of Wheels: {4}{5}",
                m_ModelName,
                Environment.NewLine,
                m_LicenseNumber,
                Environment.NewLine,
                r_AmountWheels,
                Environment.NewLine);
            foreach (Wheel wheel in r_WheelsCollection)
            {
                stringBuilder.Append(wheel.ToString());
            }

            stringBuilder.Append(m_EngineType.ToString());

            return stringBuilder.ToString();
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                 m_LicenseNumber = value;
            }
        }
        
        public List<Wheel> ListWheels
        {
            get
            {
                return r_WheelsCollection;
            }
        }

        public EngineType EngineType
        {
            get
            {
                return m_EngineType;
            }
        }

        public int AmountWheels
        {
            get
            {
                return r_AmountWheels;
            }
        }
    }
}
