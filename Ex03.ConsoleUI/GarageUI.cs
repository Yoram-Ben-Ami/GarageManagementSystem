using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{

    public class GarageUI
    {
        public static void Run(Garage i_Garage)
        {
            int userInput = 0;
            Console.Clear();
            string text = String.Format(@"
                Gas Monkey Garage Menu:

                1) Add a new vehicle to the garage
                2) Display license numbers by status
                3) Change a vehicle's status
                4) Inflate a vehicle's tires to maximum
                5) Refuel a vehicle
                6) Recharge a vehicle
                7) Display a vehicle's data
                8) Exit

                Please choose the desired action by entering the action number");

            while (userInput != 8)
            {
                userInput = UserInput.findIntExceptions(text, 1, 8);
                switch (userInput)
                {
                    case 1:
                        addNewVehicle(i_Garage);
                        break;
                    case 2:
                        displayLicenseNumbersByStatus(i_Garage);
                        break;
                    case 3:
                        changeVehicleStatus(i_Garage);
                        break;
                    case 4:
                        inflateVehicleToMax(i_Garage);
                        break;
                    case 5:
                        refuelVehicle(i_Garage);
                        break;
                    case 6:
                        rechargeVehicle(i_Garage);
                        break;
                    case 7:
                        displayVehicleData(i_Garage);
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        userInput = 0;
                        break;
                }

                Console.WriteLine("Enter any key to continue...");
                Console.ReadKey();
                Console.Clear();
                userInput = 0;
            }
        }

        private static void addNewVehicle(Garage i_Garage)
        {
            string ownerName;
            string ownerPhoneNumber;
            VehicleData vehicleData;

            UserInput.GetOwnerName(out ownerName);
            UserInput.GetPhoneNumber(out ownerPhoneNumber);
            vehicleData = UserInput.GetVehicleData();
            try
            {
                i_Garage.AddClientCard(ownerName, ownerPhoneNumber, vehicleData);
                Console.WriteLine("Vehicle added to Gas Monkey Garage successfully");
            }

            catch (VehicleAlreadyExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown Exception");

            }
        }

        private static void displayLicenseNumbersByStatus(Garage i_Garage)
        {
            ClientCard.eVehicleStatus vehicleStatus;
            List<string> licenseNumbers;
            StringBuilder message = new StringBuilder();

            UserInput.GetVehicleStatus(out vehicleStatus);
            licenseNumbers = i_Garage.GetLicenseNumbersByStatus(vehicleStatus);
            if (licenseNumbers.Count == 0)
            {
                Console.WriteLine("No vehicles in Gas Monkey garage with the following status: {0}", vehicleStatus.ToString());
            }
            else
            {
                message.AppendLine(String.Format("Vehicles with status {0} in Gas Monkey garage:", vehicleStatus.ToString()));
                foreach (string licenseNumber in licenseNumbers)
                {
                    message.AppendLine(licenseNumber);
                }
            }
            Console.WriteLine(message);
        }

        private static void changeVehicleStatus(Garage i_Garage)
        {
            ClientCard.eVehicleStatus newVehicleStatus;
            string licenseNumber;

            UserInput.GetLicenseNumber(out licenseNumber);
            UserInput.GetVehicleStatus(out newVehicleStatus);
            try
            {
                i_Garage.ChangeVehicleStatus(licenseNumber, newVehicleStatus);
                Console.WriteLine("Vehicle status changed successfuly to {0}", newVehicleStatus);
            }

            catch (KeyNotFoundException)
            {
                Console.WriteLine("No vehicles with license number {0} exist in Gas Monkey garage", licenseNumber);
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown Exception");

            }
        }

        private static void inflateVehicleToMax(Garage i_Garage)
        {
            string licenseNumber;

            UserInput.GetLicenseNumber(out licenseNumber);
            try
            {
                i_Garage.InflateWheelsToFull(licenseNumber);
                Console.WriteLine("Vehicle wheels inflated to maximum successfuly");
            }

            catch (KeyNotFoundException)
            {
                Console.WriteLine("No vehicles with license number {0} exist in the garage", licenseNumber);
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown Exception");

            }
        }

        private static void refuelVehicle(Garage i_Garage)
        {
            string licenseNumber;
            GasEngine.eFuelType fuelType;
            float fuelToAdd;

            UserInput.GetLicenseNumber(out licenseNumber);
            UserInput.GetFuelType(out fuelType);
            UserInput.GetFuelToAdd(out fuelToAdd);
            try
            {
                i_Garage.RefuelTank(licenseNumber, fuelType, fuelToAdd);
                Console.WriteLine("Vehicle fueled successfuly");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("No vehicles with license number {0} exist in the garage", licenseNumber);
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("This is not a fuel based vehicle");
            }

            catch (OutOfRangeException ex)
            {
                Console.WriteLine("Invalid input. Cannot fuel more than the maximum capacity of {0}", ex.MaxValue);
            }

            catch (ArgumentException)
            {
                Console.WriteLine("Invalid input. Cannot fuel this vehicle with fuel type {0}", fuelType);
            }

            catch (Exception)
            {
                Console.WriteLine("Unknown Exception");

            }
        }

        private static void rechargeVehicle(Garage i_Garage)
        {
            string licenseNumber;
            float batteryTimeToAdd;

            UserInput.GetLicenseNumber(out licenseNumber);
            UserInput.GetBatteryTimeToAdd(out batteryTimeToAdd);
            try
            {
                i_Garage.ChargeBattery(licenseNumber, batteryTimeToAdd);
                Console.WriteLine("Vehicle charged successfuly");
            }

            catch (KeyNotFoundException)
            {
                Console.WriteLine("No vehicles with license number {0} exist in the garage", licenseNumber);
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("This is not an electric vehicle");
            }

            catch (OutOfRangeException ex)
            {
                Console.WriteLine("Invalid input. Cannot charge more than the maximum capacity of {0}", ex.MaxValue);
            }
        }

        private static void displayVehicleData(Garage i_Garage)
        {
            string licenseNumber = string.Empty;
            ClientCard cardToDisplay;
            Vehicle vehicleToDisplay;
            VehicleCreator.eVehicleType vehicleType = 0;
            StringBuilder output = new StringBuilder();

            UserInput.GetLicenseNumber(out licenseNumber);
            try
            {
                cardToDisplay = i_Garage.GetClientCard(licenseNumber);
                vehicleToDisplay = cardToDisplay.Vehicle;
                vehicleType = Vehicle.GetVehicleType(vehicleToDisplay);

                output.Append(String.Format(@"License Number: {0}
                    Model Name: {1}
                    Owner Name: {2}
                    Vehicle Status: {3}
                    Energy Percentage: {4} %",
                vehicleToDisplay.LicenseNumber, vehicleToDisplay.Model, cardToDisplay.OwnerName, cardToDisplay.VehicleStatus, vehicleToDisplay.EnergyType.EnergyLeft));

                switch (vehicleType)
                {
                    case VehicleCreator.eVehicleType.FueledCar:
                        output.Append(String.Format(@"
                            Fuel Type: {0}
                            Fuel Tank Capacity: {1} Liters
                            Current Amount of Fuel: {2} Liters",
                        ((GasEngine)vehicleToDisplay.EnergyType).FuelType, ((GasEngine)vehicleToDisplay.EnergyType).MaxCapacityOfFuel, ((GasEngine)vehicleToDisplay.EnergyType).CurrentAmountOfFuel));
                        output.Append(String.Format(@"
                            Car Color: {0}
                            Number of Doors: {1}",
                            ((Car)vehicleToDisplay).CarColor.ToString(), ((Car)vehicleToDisplay).NumberOfDoors));
                        break;
                    case VehicleCreator.eVehicleType.ElectricCar:
                        output.Append(String.Format(@"
                            Battery Capacity: {0} Hours
                            Remaining BatteryTime: {1} Hours",
                            ((ElectricEngine)vehicleToDisplay.EnergyType).FullBatteryTime, ((ElectricEngine)vehicleToDisplay.EnergyType).BatteryTimeLeft));
                        output.Append(String.Format(@"
                            Car Color: {0}
                            Number of Doors: {1}",
                            ((Car)vehicleToDisplay).CarColor.ToString(), ((Car)vehicleToDisplay).NumberOfDoors));
                        break;
                    case VehicleCreator.eVehicleType.FueledMotorcycle:
                        output.Append(String.Format(@"
                            Fuel Type: {0}
                            Fuel Tank Capacity: {1} Liters
                            Current Amount of Fuel: {2} Liters",
                            ((GasEngine)vehicleToDisplay.EnergyType).FuelType, ((GasEngine)vehicleToDisplay.EnergyType).MaxCapacityOfFuel, ((GasEngine)vehicleToDisplay.EnergyType).CurrentAmountOfFuel));
                        output.Append(String.Format(@"
                            License Type: {0}
                            Engine Volume: {1}",
                            ((Motorcycle)vehicleToDisplay).LicenseType.ToString(), ((Motorcycle)vehicleToDisplay).EngineSize));
                        break;
                    case VehicleCreator.eVehicleType.ElectricMotorcycle:
                        output.Append(String.Format(@"
                                Battery Capacity: {0} Hours
                                Remaining BatteryTime: {1} Hours",
                            ((ElectricEngine)vehicleToDisplay.EnergyType).FullBatteryTime, ((ElectricEngine)vehicleToDisplay.EnergyType).BatteryTimeLeft));
                        output.Append(String.Format(@"
                                License Type: {0}
                                Engine Volume: {1}",
                                ((Motorcycle)vehicleToDisplay).LicenseType.ToString(), ((Motorcycle)vehicleToDisplay).EngineSize));
                        break;
                    case VehicleCreator.eVehicleType.Truck:
                        output.Append(String.Format(@"
                            Fuel Type: {0}
                            Fuel Tank Capacity: {1} Liters
                            Current Amount of Fuel: {2} Liters
                            Cargo is Cooled? {3}
                            Cargo Tank Volume: {4}",
                            ((GasEngine)vehicleToDisplay.EnergyType).FuelType, ((GasEngine)vehicleToDisplay.EnergyType).MaxCapacityOfFuel, ((GasEngine)vehicleToDisplay.EnergyType).CurrentAmountOfFuel, ((Truck)vehicleToDisplay).IsCargoCooled ? "Yes" : "No", ((Truck)vehicleToDisplay).TankVolume));
                        break;
                    default:
                        break;
                }
                output.AppendLine("\nWheels Information:");
                for (int i = 0; i < vehicleToDisplay.Wheels.Count; i++)
                {
                    output.Append(String.Format(@"
                        Wheel {0}:
                        Manufacturer: {1}
                        Max Air Pressure: {2}
                        Current Air Pressure: {3}",
                        (i + 1), vehicleToDisplay.Wheels[i].Manufactur, vehicleToDisplay.Wheels[i].FullAirPressure, vehicleToDisplay.Wheels[i].CurrentAirPressure));
                }
            }

            catch (KeyNotFoundException)
            {
                Console.WriteLine("No vehicles with license number {0} exist in the garage", licenseNumber);
            }
            Console.WriteLine(output);
        }

    }
}
