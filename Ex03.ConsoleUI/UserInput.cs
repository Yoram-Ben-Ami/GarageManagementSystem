using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class UserInput
    {

        public static VehicleData GetVehicleData()
        {
            VehicleData vehicleData = new VehicleData();

            getModel(out vehicleData.m_Model);
            GetLicenseNumber(out vehicleData.m_VehicleLicenseNumber);
            getVehicleType(out vehicleData.m_VehicleType);
            getWheelsManufacturer(out vehicleData.m_WheelManufacturer);
            getWheelsCurrentAirPressure(vehicleData.m_VehicleType, out vehicleData.m_WheelCurrentAirPressure);
            getDataByVehicleType(vehicleData);

            return vehicleData;
        }

        public static void getDataByVehicleType(VehicleData o_VehicleData)
        {
            VehicleCreator.eVehicleType vehicleType = o_VehicleData.m_VehicleType;

            switch (vehicleType)
            {
                case VehicleCreator.eVehicleType.FueledCar:
                    getCarColor(out o_VehicleData.m_CarColor);
                    getCarNumberOfDoors(out o_VehicleData.m_CarNumberOfDoors);
                    getCurrentAmountOfFuel(out o_VehicleData.m_CurrentAmountOfFuel, Car.k_MaxCapacityOfFuel);
                    break;

                case VehicleCreator.eVehicleType.ElectricCar:
                    getCarColor(out o_VehicleData.m_CarColor);
                    getCarNumberOfDoors(out o_VehicleData.m_CarNumberOfDoors);
                    getRemainingBatteryTime(out o_VehicleData.m_BatteryTimeLeft, Car.k_FullBatteryTime);
                    break;

                case VehicleCreator.eVehicleType.FueledMotorcycle:
                    getMotorcycleLicenseType(out o_VehicleData.m_MotorcycleLicenseType);
                    getMotorcycleEngineVolume(out o_VehicleData.m_MotorcycleEngineVolume);
                    getCurrentAmountOfFuel(out o_VehicleData.m_CurrentAmountOfFuel, Motorcycle.k_MaxCapacityOfFuel);
                    break;

                case VehicleCreator.eVehicleType.ElectricMotorcycle:
                    getMotorcycleLicenseType(out o_VehicleData.m_MotorcycleLicenseType);
                    getMotorcycleEngineVolume(out o_VehicleData.m_MotorcycleEngineVolume);
                    getRemainingBatteryTime(out o_VehicleData.m_BatteryTimeLeft, Motorcycle.k_FullBatteryTime);
                    break;

                case VehicleCreator.eVehicleType.Truck:
                    getCurrentAmountOfFuel(out o_VehicleData.m_CurrentAmountOfFuel, Truck.k_MaxCapacityOfFuel);
                    getIsTruckCargoCooled(out o_VehicleData.m_TruckIsCargoCooled);
                    getTruckTankVolume(out o_VehicleData.m_TruckCargoTankVolume);
                    break;

                default:
                    break;
            }
        }

        private static void getModel(out string o_VehicleModelName)
        {
            o_VehicleModelName = findExceptions("model");
        }

        public static void GetLicenseNumber(out string o_LicenseNumber)
        {
            o_LicenseNumber = findExceptions("license number");
        }

        private static void getWheelsManufacturer(out string o_WheelManufacturerName)
        {
            o_WheelManufacturerName = findExceptions("wheels manufacturer");
        }

        private static void getWheelsCurrentAirPressure(VehicleCreator.eVehicleType i_VehicleType, out float o_WheelCurrentAirPressure)
        {
            float maxAirPressure = 0;

            switch (i_VehicleType)
            {
                case VehicleCreator.eVehicleType.FueledCar:
                case VehicleCreator.eVehicleType.ElectricCar:
                    maxAirPressure = Car.k_FullAirPressure;
                    break;

                case VehicleCreator.eVehicleType.FueledMotorcycle:
                case VehicleCreator.eVehicleType.ElectricMotorcycle:
                    maxAirPressure = Motorcycle.k_FullAirPressure;
                    break;

                case VehicleCreator.eVehicleType.Truck:
                    maxAirPressure = Truck.k_FullAirPressure;
                    break;

                default:
                    break;
            }
            o_WheelCurrentAirPressure = findFloatExceptions("current air pressure", 0, maxAirPressure);
        }

        private static void getTruckTankVolume(out float o_TruckTankVolume)
        {
            o_TruckTankVolume = findFloatExceptions("truck's tank volume", 0, float.MaxValue);
        }

        private static void getRemainingBatteryTime(out float o_RemainingBatteryTime, float i_MaxBatteryTime)
        {
            o_RemainingBatteryTime = findFloatExceptions("battery time in hours", 0, i_MaxBatteryTime);
        }

        private static void getCurrentAmountOfFuel(out float o_CurrentAmountOfFuel, float i_MaxAmountOfFuel)
        {
            o_CurrentAmountOfFuel = findFloatExceptions("current amount of fuel", 0, i_MaxAmountOfFuel);
        }

        public static void GetFuelToAdd(out float o_FuelToAdd)
        {
            Console.Clear();
            string text = "amout of fuel you would like to add";
            o_FuelToAdd = findFloatExceptions(text, 0, float.MaxValue);
        }

        public static void GetBatteryTimeToAdd(out float o_BatteryTimeToAdd)
        {
            Console.Clear();
            string text = "amout of battery energy you would like to add";
            o_BatteryTimeToAdd = findFloatExceptions(text, 0, float.MaxValue);
        }

        private static void getMotorcycleEngineVolume(out int o_MotorcycleEngineVolume)
        {
            Console.Clear();
            string text = "Please enter the motorcycle's engine volume";
            o_MotorcycleEngineVolume = findIntExceptions(text, 0, int.MaxValue);
        }

        private static void getVehicleType(out VehicleCreator.eVehicleType o_VehicleType)
        {
            Console.Clear();
            string vehicleTypeOptions = String.Format(@"
                Please choose the vehicle's type:

                1) Fueled Car
                2) Electric Car
                3) Fueled Motorcycle
                4) Electric Motorcycle
                5) Truck

                Please choose the vehicle type by entering the type number");

            o_VehicleType = (VehicleCreator.eVehicleType)(findIntExceptions(vehicleTypeOptions, 1, 5));
        }

        private static void getCarColor(out Car.eCarColor o_CarColor)
        {
            Console.Clear();
            string colorOptions = String.Format(@"
                Please choose the car's color:

                1) Grey
                2) White
                3) Black
                4) Blue

                Please choose the car's color by entering the color number");
            o_CarColor = (Car.eCarColor)findIntExceptions(colorOptions, 1, 4);
        }

        private static void getCarNumberOfDoors(out Car.eNumberOfDoors o_CarNumberOfDoors)
        {
            Console.Clear();
            string numberOfDoorsOptions = String.Format(@"
                Please enter the car's number of doors:

                2) Two (2)
                3) Three (3)
                4) Four (4)
                5) Five (5)");
            o_CarNumberOfDoors = (Car.eNumberOfDoors)findIntExceptions(numberOfDoorsOptions, 2, 5);
        }

        private static void getMotorcycleLicenseType(out Motorcycle.eLicenseType o_MotorcycleLicenseType)
        {
            Console.Clear();
            string licenseTypeOptions = String.Format(@"
                Please choose the motorcycle's license type:

                1) A
                2) A1
                3) B1
                4) BB

                Please choose the motorcycle's license type by entering the license type number");
            o_MotorcycleLicenseType = (Motorcycle.eLicenseType)findIntExceptions(licenseTypeOptions, 1, 4);
        }

        private static void getIsTruckCargoCooled(out bool o_TruckCargoCooled)
        {
            bool cargoIsCooled;
            Console.Clear();
            string cargoIsCoolesOptions = String.Format(@"
                Does the truck conttain a cooled cargo?:

                1) Yes
                2) No");
            cargoIsCooled = (findIntExceptions(cargoIsCoolesOptions, 1, 2) == 1);
            o_TruckCargoCooled = cargoIsCooled;
        }

        public static void GetVehicleStatus(out ClientCard.eVehicleStatus o_VehicleStatus)
        {
            Console.Clear();
            string statusOptions = String.Format(@"
                Please choose vehicle status:

                1) In Repair
                2) Repaired
                3) Payed

                Please choose the desired vehicle status by entering the status number");
            o_VehicleStatus = (ClientCard.eVehicleStatus)findIntExceptions(statusOptions, 1, 3);
        }


        public static void GetFuelType(out GasEngine.eFuelType o_FuelType)
        {
            Console.Clear();
            string fuelTypeOptions = String.Format(@"
                Please choose a type of fuel:

                1) Octan95
                2) Octan96
                3) Octan98
                4) Soler

                Please choose the desired type of fuel by entering the fuel number");
            o_FuelType = (GasEngine.eFuelType)findIntExceptions(fuelTypeOptions, 1, 4);
        }

        public static bool isIntInRange(out int o_UserInput, int i_Min, int i_Max)
        {
            String inputString = Console.ReadLine();
            if (!int.TryParse(inputString, out o_UserInput))
            {
                throw new FormatException();
            }

            if (!IsBetween(o_UserInput, i_Min, i_Max))
            {
                throw new OutOfRangeException(new Exception(), i_Min, i_Max);
            }

            return true;
        }

        private static bool isFloatInRange(out float o_UserInput, float i_Min, float i_Max)
        {
            string inputString;
            inputString = Console.ReadLine();
            if (!float.TryParse(inputString, out o_UserInput))
            {
                throw new FormatException();
            }

            if (!IsBetween(o_UserInput, i_Min, i_Max))
            {
                throw new OutOfRangeException(new Exception(), i_Min, i_Max);
            }

            return true;
        }

        private static bool getValidName(out string o_Name)
        {
            string inputString;

            inputString = Console.ReadLine();
            o_Name = string.IsNullOrEmpty(inputString) ? throw new ArgumentNullException() : (!inputString.All(char.IsLetter) ? throw new FormatException() : inputString);

            return true;
        }

        private static bool getValidPhoneNumber(out string o_PhoneNumber)
        {
            string inputString;

            inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException();
            }

            if (inputString.Length != 10)
            {
                throw new OutOfRangeException(new Exception(), 10, 10);
            }

            foreach (char c in inputString)
            {
                if (c < '0' || c > '9')
                {
                    throw new FormatException();
                }
            }

            o_PhoneNumber = inputString;
            return true;
        }

        private static string findExceptions(string part)
        {
            bool isValid = false;
            string userInput = string.Empty;

            Console.WriteLine("Please enter the {0}", part);
            while (!isValid)
            {
                try
                {
                    userInput = Console.ReadLine();
                    isValid = string.IsNullOrEmpty(userInput) ? throw new ArgumentNullException() : true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("manufacturer name can't be empty. Please enter the wheels' manufacturer name");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown Exception");
                }
            }
            return userInput;
        }

        private static float findFloatExceptions(string part, float min, float max)
        {
            bool isValid = false;
            float userInput = 0;

            Console.WriteLine("Please enter the {0}", part);
            while (!isValid)
            {
                try
                {
                    isValid = isFloatInRange(out userInput, 0, max);
                }

                catch (FormatException)
                {
                    Console.WriteLine("Please enter a floating point number");
                }

                catch (OutOfRangeException ex)
                {
                    Console.WriteLine("Please enter a floating point number between {0} and {1}", ex.MinValue, ex.MaxValue);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Unknown Exception");
                }
            }
            return userInput;
        }

        public static int findIntExceptions(string text, int min, int max)
        {
            bool isValid = false;
            int userInput = 0;

            Console.WriteLine(text);
            while (!isValid)
            {
                try
                {
                    isValid = isIntInRange(out userInput, min, max);
                }

                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number");
                }

                catch (OutOfRangeException ex)
                {
                    Console.WriteLine("Please enter a number between {0} and {1}", ex.MinValue, ex.MaxValue);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Unknown Exception");
                }
            }
            return userInput;
        }

        public static void GetPhoneNumber(out string o_PhoneNumber)
        {
            bool isValid = false;
            string userInput = string.Empty;
            Console.Clear();
            Console.WriteLine("Please enter the owner's phone number");
            while (!isValid)
            {
                try
                {
                    isValid = getValidPhoneNumber(out userInput);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Phone number can't be empty. Please enter the owner's phone number");
                }
                catch (OutOfRangeException)
                {
                    Console.WriteLine("Phone number must be 10 digits");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Phone number must contain only digits");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown Exception");
                }
            }

            o_PhoneNumber = userInput;
        }

        public static void GetOwnerName(out string o_OwnerName)
        {
            Console.Clear();
            bool isValid = false;
            string userInput = string.Empty;
            Console.WriteLine("Please enter the owner's name");
            while (!isValid)
            {
                try
                {
                    isValid = getValidName(out userInput);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Owner name can't be empty. Please enter the owner's name");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Owner name must contain only letters");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown Exception");
                }
            }
            o_OwnerName = userInput;
        }

        public static bool IsBetween<T>(this T item, T start, T end) where T : IComparable
        {
            return item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0;
        }
    }
}




