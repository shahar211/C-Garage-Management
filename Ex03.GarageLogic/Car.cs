namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class Car : Vehicle
    {
        private eColorType m_CarColor;
        private eCarDoorsAmount m_DoorNumber;

        public Car(int i_CarWheelAmount, float i_CarMaxAirPressure, EngineType i_EngineType)
            : base(i_CarMaxAirPressure, i_CarWheelAmount, i_EngineType)
        {
        }

        public eColorType CarColor
        {
            set
            {
                m_CarColor = value;
            }
        }

        public eCarDoorsAmount DoorNumber
        {
            set
            {
                m_DoorNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(base.ToString());

            stringBuilder.AppendFormat(
                "Car Color: {0}, Door Number: {1}{2}",
                m_CarColor.ToString(),
                m_DoorNumber.ToString(),
                Environment.NewLine);

            return stringBuilder.ToString();
        }
    }
}
