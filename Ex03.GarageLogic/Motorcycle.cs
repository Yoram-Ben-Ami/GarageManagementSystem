using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A = 1,
            A1,
            B1,
            BB
        }

        public const int k_NumberOfWheels = 2;
        public const int k_FullAirPressure = 31;
        public const float k_FullBatteryTime = 2.8f;
        public const float k_MaxCapacityOfFuel = 5.4f;
        private int m_engineSize;
        private eLicenseType m_LicenseType;
        public static readonly GasEngine.eFuelType fuelType = GasEngine.eFuelType.Octan98;


        public Motorcycle(string i_Model, string i_LicenseNumber, List<Wheel> i_Wheels, Energy i_EnergyType, eLicenseType i_LicenseType, int i_EngineSize) : base(i_Model, i_LicenseNumber, i_Wheels, i_EnergyType)
        {
            this.m_LicenseType = i_LicenseType;
            this.m_engineSize = i_EngineSize;
        }

        public eLicenseType LicenseType
        {
            get => m_LicenseType;
        }

        public int EngineSize
        {
            get => m_engineSize;
        }
    }
}
