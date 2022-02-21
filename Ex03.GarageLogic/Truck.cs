namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class Truck : Vehicle
    {
        private bool m_IsDrivingRefrigeratedContent;
        private float m_CargoVolume;

        public Truck(int i_TruckWheelAmount, float i_TrucMaxAirPressure, EngineType i_EngineType)
            : base(i_TrucMaxAirPressure, i_TruckWheelAmount, i_EngineType)
        {
        }

        public bool RefrigeratedContent
        {
            set
            {
                m_IsDrivingRefrigeratedContent = value;
            }
        }

        public float CargoVolume
        {
            set
            {
                m_CargoVolume = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(base.ToString());

            stringBuilder.AppendFormat(
                "Is Driving Refrigerated Content: {0}, Cargo Size: {1}{2}",
                m_IsDrivingRefrigeratedContent,
                m_CargoVolume,
                Environment.NewLine);
            
            return stringBuilder.ToString();
        }
    }
}
