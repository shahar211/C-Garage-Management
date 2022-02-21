namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class CarOwnerDetails
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumeber;
        private Vehicle m_VehicleInGarage;
        private eStateCar m_OwnerCarState;

        public CarOwnerDetails(string i_OwnerName, string i_OwnerPhoneNumeber, eStateCar i_CarState, Vehicle i_VehicleInGarage)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumeber = i_OwnerPhoneNumeber;
            m_OwnerCarState = i_CarState;
            m_VehicleInGarage = i_VehicleInGarage;
        }

        public Vehicle VehicleInGarage
        {
            get
            {
                return m_VehicleInGarage;
            }
        }

        public eStateCar eCarState
        {
            get
            {
                return m_OwnerCarState;
            }

            set
            {
                m_OwnerCarState = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(m_VehicleInGarage.ToString());
            stringBuilder.AppendFormat(
                "vehicle status: {0}, owner name: {1}, owner phone: {2}{3}",
                m_OwnerCarState.ToString(),
                r_OwnerName,
                r_OwnerPhoneNumeber,
                Environment.NewLine);

            return stringBuilder.ToString();
        }
    }
}
