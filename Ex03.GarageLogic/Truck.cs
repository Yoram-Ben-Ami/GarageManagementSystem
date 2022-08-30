using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {

        public const int k_NumberOfWheels = 16;
        public const int k_FullAirPressure = 25;
        public const float k_MaxCapacityOfFuel = 135;
        private bool m_IsCargoCooled;
        private float m_CargoTankVolume;
        public const GasEngine.eFuelType k_FuelType = GasEngine.eFuelType.Soler;

        public Truck(string i_Model, string i_LicenseNumber, List<Wheel> i_Wheels, Energy i_EnergyType, bool i_IsCargoCooled, float i_CargoTankVolume) : base(i_Model, i_LicenseNumber, i_Wheels, i_EnergyType)
        {
            this.m_IsCargoCooled = i_IsCargoCooled;
            this.m_CargoTankVolume = i_CargoTankVolume;
        }

        public bool IsCargoCooled
        {
            get => m_IsCargoCooled;
            set => m_IsCargoCooled = value;
        }

        public float TankVolume
        {
            get => m_CargoTankVolume;
        }
    }
}
