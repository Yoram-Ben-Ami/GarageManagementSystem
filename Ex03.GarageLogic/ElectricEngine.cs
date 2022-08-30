using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Energy
    {
        private float m_BatteryTimeLeft;
        private float m_FullBatteryTime;

        public ElectricEngine(float i_BatteryTimeLeft, float i_FullBatteryTime)
        {
            this.m_BatteryTimeLeft = i_BatteryTimeLeft;
            this.m_FullBatteryTime = i_FullBatteryTime;
        }

        public float BatteryTimeLeft
        {
            get => m_BatteryTimeLeft;
            set => m_BatteryTimeLeft = value;
        }

        public float FullBatteryTime
        {
            get => m_FullBatteryTime;
        }

        public void RechargeBattery(float i_HoursToAdd)
        {
            if (i_HoursToAdd + m_BatteryTimeLeft > m_FullBatteryTime)
            {
                throw new OutOfRangeException(new Exception(), 0, m_FullBatteryTime);
            }
            else
            {
                m_BatteryTimeLeft += i_HoursToAdd;
            }

            m_EnergyLeft = (float)(m_BatteryTimeLeft * 100.0f / m_FullBatteryTime);
        }
    }
}
