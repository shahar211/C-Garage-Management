using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheels
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;//we are not sure about this now
        private readonly float m_MaxAirPressure;

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public Wheels(string i_ManufacturerName,float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressure = i_MaxAirPressure;
        }
        public void AddAirPressureToWheel(float i_AirPressureToAdd)
        {
            if(m_CurrentAirPressure+i_AirPressureToAdd<=m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirPressureToAdd;///maybe need exepction
            }
        }

    }
}
