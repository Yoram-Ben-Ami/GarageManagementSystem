using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColor
        {
            Grey = 1,
            White,
            Black,
            Blue
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public const int k_NumberOfWheels = 4;
        public const int k_FullAirPressure = 52;
        public const float k_FullBatteryTime = 4.5f;
        public const float k_MaxCapacityOfFuel = 52f;
        public const GasEngine.eFuelType fuelType = GasEngine.eFuelType.Octan95;
        private eCarColor carColor;
        private eNumberOfDoors numberOfDoors;

        public Car(string i_Model, string i_LicenseNumber, List<Wheel> u_Wheels, Energy i_TypeOfEnergy, eCarColor i_CarColor, eNumberOfDoors i_NumOfDoors) : base(i_Model, i_LicenseNumber, u_Wheels, i_TypeOfEnergy)
        {
            this.carColor = i_CarColor;
            this.numberOfDoors = i_NumOfDoors;
        }

        public eCarColor CarColor
        {
            get => carColor;
            set => carColor = value;
        }

        public eNumberOfDoors NumberOfDoors
        {
            get => numberOfDoors;
            set => numberOfDoors = value;
        }
    }
}
