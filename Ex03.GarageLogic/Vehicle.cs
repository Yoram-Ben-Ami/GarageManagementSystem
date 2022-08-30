using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_Model;
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        private Energy m_EnergyType;

        public Vehicle(string i_Model, string i_LicenseNumber, List<Wheel> i_Wheels, Energy i_EnergyType)
        {
            this.m_Model = i_Model;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Wheels = i_Wheels;
            this.m_EnergyType = i_EnergyType;
        }

        public string Model
        {
            get => m_Model;
        }

        public string LicenseNumber
        {
            get => m_LicenseNumber;
        }

        public List<Wheel> Wheels
        {
            get => m_Wheels;
            set => m_Wheels = value;
        }

        public Energy EnergyType
        {
            get => m_EnergyType;
        }

        public static VehicleCreator.eVehicleType GetVehicleType(Vehicle i_Vehicle)
        {
            VehicleCreator.eVehicleType vehicleType;
            if (i_Vehicle is Car && i_Vehicle.EnergyType is GasEngine)
            {
                vehicleType = i_Vehicle.EnergyType is GasEngine ? VehicleCreator.eVehicleType.FueledCar : VehicleCreator.eVehicleType.ElectricCar;
            }
            else if (i_Vehicle is Motorcycle)
            {
                vehicleType = i_Vehicle.EnergyType is GasEngine ? VehicleCreator.eVehicleType.FueledMotorcycle : VehicleCreator.eVehicleType.ElectricMotorcycle;
            }
            else
            {
                vehicleType = VehicleCreator.eVehicleType.Truck;
            }
            return vehicleType;
        }
    }
}
