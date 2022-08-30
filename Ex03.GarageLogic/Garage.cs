using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
    public class Garage
    {
        readonly List<ClientCard> m_ClientsCards;

        public Garage()
        {
            m_ClientsCards = new List<ClientCard>();
        }

        public ClientCard GetClientCard(string i_LicenseNumber)
        {
            ClientCard clientCard;
            clientCard = m_ClientsCards.Find(card => card.Vehicle.LicenseNumber.Equals(i_LicenseNumber));

            if (clientCard == null)
            {
                throw new KeyNotFoundException();
            }
            return clientCard;
        }

        public void AddClientCard(string i_OwnerName, string i_OwnerPhoneNumber, VehicleData i_VehicleData)
        {
            ClientCard i_ExistingCard, i_NewClientCard;
            Vehicle i_NewVehicle;

            try
            {
                i_ExistingCard = GetClientCard(i_VehicleData.m_VehicleLicenseNumber);
            }

            catch (KeyNotFoundException)
            {
                i_ExistingCard = null;
            }

            if (i_ExistingCard == null)
            {
                i_NewVehicle = VehicleCreator.CreateVehicle(i_VehicleData);
                i_NewClientCard = new ClientCard(i_OwnerName, i_OwnerPhoneNumber, ClientCard.eVehicleStatus.InRepair, i_NewVehicle);
                m_ClientsCards.Add(i_NewClientCard);
            }

            else
            {
                i_ExistingCard.VehicleStatus = ClientCard.eVehicleStatus.InRepair;
                throw new VehicleAlreadyExistsException(new Exception(), i_ExistingCard.Vehicle.LicenseNumber);
            }
        }

        public List<string> GetLicenseNumbersByStatus(ClientCard.eVehicleStatus i_VehicleStatus)
        {
            List<string> licenseNumbers = new List<string>();

            foreach (ClientCard card in m_ClientsCards)
            {
                if (card.VehicleStatus == i_VehicleStatus)
                {
                    licenseNumbers.Add(card.Vehicle.LicenseNumber);
                }
            }

            return licenseNumbers;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, ClientCard.eVehicleStatus i_UpdatedStatus)
        {
            ClientCard clientCard = GetClientCard(i_LicenseNumber);
            clientCard.VehicleStatus = i_UpdatedStatus;
        }

        public void InflateWheelsToFull(string i_LicenseNumber)
        {
            ClientCard clientCard = GetClientCard(i_LicenseNumber);
            foreach (Wheel wheel in clientCard.Vehicle.Wheels)
            {
                wheel.fullInflateWheel();
            }
        }

        public void RefuelTank(string i_LicenseNumber, GasEngine.eFuelType i_FuelType, float i_FuelToAdd)
        {
            GasEngine fuelTankToFill = null;
            ClientCard clientCard = GetClientCard(i_LicenseNumber);

            fuelTankToFill = clientCard.Vehicle.EnergyType as GasEngine;
            if (fuelTankToFill == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                fuelTankToFill.RefuelTank(i_FuelToAdd, i_FuelType);
            }
        }

        public void ChargeBattery(string i_LicenseNumber, float i_HoursToCharge)
        {
            ElectricEngine batteryToCharge = null;
            ClientCard clientCard = GetClientCard(i_LicenseNumber);

            batteryToCharge = clientCard.Vehicle.EnergyType as ElectricEngine;
            if (batteryToCharge == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                batteryToCharge.RechargeBattery(i_HoursToCharge);
            }
        }
    }
}
