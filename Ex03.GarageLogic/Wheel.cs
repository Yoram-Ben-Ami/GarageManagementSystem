using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufactur;
        private float m_MurrentAirPressure;
        private float m_FullAirPressure;

        public Wheel(string i_Manufactur, float i_CurrentAirPressure, float i_FullAirPressure)
        {
            this.m_Manufactur = i_Manufactur;
            this.m_MurrentAirPressure = i_CurrentAirPressure;
            this.m_FullAirPressure = i_FullAirPressure;
        }

        public string Manufactur
        {
            get => m_Manufactur;
            set => m_Manufactur = value;
        }

        public float CurrentAirPressure
        {
            get => m_MurrentAirPressure;
            set => m_MurrentAirPressure = value;
        }

        public float FullAirPressure
        {
            get => m_FullAirPressure;
        }

        public void inflateWheel(float i_AirToAdd)
        {
            if (m_MurrentAirPressure + i_AirToAdd > m_FullAirPressure)
            {

                throw new OutOfRangeException(new Exception(), 0, m_FullAirPressure);
            }
            else
            {
                m_MurrentAirPressure += i_AirToAdd;
            }
        }

        public void fullInflateWheel()
        {
            m_MurrentAirPressure = m_FullAirPressure;
        }
    }
}