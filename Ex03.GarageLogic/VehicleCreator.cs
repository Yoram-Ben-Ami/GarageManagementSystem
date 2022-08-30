using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public enum eVehicleType
        {
            FueledCar = 1 ,
            ElectricCar,
            FueledMotorcycle,
            ElectricMotorcycle,
            Truck
        }

        public static Vehicle CreateVehicle(VehicleData i_VehicleData)
        {
            Vehicle newVehicleCreated = null;
            Energy energy;
            List<Wheel> wheels;

            switch (i_VehicleData.m_VehicleType)
            {
                case eVehicleType.FueledCar:
                    energy = new GasEngine(Car.fuelType, i_VehicleData.m_CurrentAmountOfFuel, Car.k_MaxCapacityOfFuel);
                    wheels = CreateWheels(i_VehicleData, Car.k_NumberOfWheels, Car.k_FullAirPressure);
                    newVehicleCreated = CreateCar(i_VehicleData, wheels, energy);
                    break;

                case eVehicleType.ElectricCar:
                    energy = new ElectricEngine(i_VehicleData.m_BatteryTimeLeft, Car.k_FullBatteryTime); ;
                    wheels = CreateWheels(i_VehicleData, Car.k_NumberOfWheels, Car.k_FullAirPressure);
                    newVehicleCreated = CreateCar(i_VehicleData, wheels, energy);
                    break;

                case eVehicleType.FueledMotorcycle:
                    energy = new GasEngine(Motorcycle.fuelType, i_VehicleData.m_CurrentAmountOfFuel, Motorcycle.k_MaxCapacityOfFuel);

                    wheels = CreateWheels(i_VehicleData, Motorcycle.k_NumberOfWheels, Motorcycle.k_FullAirPressure);
                    newVehicleCreated = CreateMotorcycle(i_VehicleData, wheels, energy);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    energy = new ElectricEngine(i_VehicleData.m_BatteryTimeLeft, Motorcycle.k_FullBatteryTime);
                    wheels = CreateWheels(i_VehicleData, Motorcycle.k_NumberOfWheels, Motorcycle.k_FullAirPressure);
                    newVehicleCreated = CreateMotorcycle(i_VehicleData, wheels, energy);
                    break;

                case eVehicleType.Truck:
                    energy = new GasEngine(Truck.k_FuelType, i_VehicleData.m_CurrentAmountOfFuel, Truck.k_MaxCapacityOfFuel);
                    wheels = CreateWheels(i_VehicleData, Truck.k_NumberOfWheels, Truck.k_FullAirPressure);
                    newVehicleCreated = CreateTruck(i_VehicleData, wheels, energy);
                    break;
            }

            return newVehicleCreated;
        }

        public static Vehicle CreateCar(VehicleData i_VehicleData, List<Wheel> i_Wheels, Energy i_EnergyType)
        {
            return new Car(i_VehicleData.m_Model, i_VehicleData.m_VehicleLicenseNumber, i_Wheels, i_EnergyType, i_VehicleData.m_CarColor, i_VehicleData.m_CarNumberOfDoors);
        }

        public static Vehicle CreateMotorcycle(VehicleData i_VehicleData, List<Wheel> i_Wheels, Energy i_EnergyType)
        {
            return new Motorcycle(i_VehicleData.m_Model, i_VehicleData.m_VehicleLicenseNumber, i_Wheels, i_EnergyType, i_VehicleData.m_MotorcycleLicenseType, i_VehicleData.m_MotorcycleEngineVolume);
        }

        public static Vehicle CreateTruck(VehicleData i_VehicleData, List<Wheel> i_Wheels, Energy i_EnergyType)
        {
            return new Truck(i_VehicleData.m_Model, i_VehicleData.m_VehicleLicenseNumber, i_Wheels, i_EnergyType, i_VehicleData.m_TruckIsCargoCooled, i_VehicleData.m_TruckCargoTankVolume);
        }

        public static List<Wheel> CreateWheels(VehicleData i_VehicleData, int i_NumberOfWheels, float i_FullAirPressure)
        {
            List<Wheel> wheels = new List<Wheel>();

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheel newWheel = new Wheel(i_VehicleData.m_WheelManufacturer, i_VehicleData.m_WheelCurrentAirPressure, i_FullAirPressure);
                wheels.Add(newWheel);
            }

            return wheels;
        }
    }
}
