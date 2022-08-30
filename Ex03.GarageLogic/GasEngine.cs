using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasEngine : Energy
    {
        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        private float m_CurrentAmountOfFuel;
        private float m_MaxCapacityOfFuel;
        private eFuelType m_FuelType;

        public GasEngine(eFuelType i_FuelType, float i_CurrentAmountOfFuel, float i_MaxCapacityOfFuel)
        {
            this.m_FuelType = i_FuelType;
            this.m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
            this.m_MaxCapacityOfFuel = i_MaxCapacityOfFuel;
        }

        public eFuelType FuelType
        {
            get => m_FuelType;
        }

        public float CurrentAmountOfFuel
        {
            get => m_CurrentAmountOfFuel;
            set => m_CurrentAmountOfFuel = value;
        }

        public float MaxCapacityOfFuel
        {
            get => m_MaxCapacityOfFuel;
        }

        public void RefuelTank(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (this.m_FuelType == i_FuelType)
            {
                if (m_CurrentAmountOfFuel + i_FuelToAdd > m_MaxCapacityOfFuel)
                {
                    throw new OutOfRangeException(new Exception(), 0, m_MaxCapacityOfFuel);
                }
                    m_CurrentAmountOfFuel += i_FuelToAdd;
                    m_EnergyLeft = (float)(m_CurrentAmountOfFuel * 100.0f / m_MaxCapacityOfFuel);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
