using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ClientCard
    {
        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Payed
        }
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;


        public ClientCard(string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_VehicleStatus, Vehicle i_Vehicle)
        {
            this.m_Vehicle = i_Vehicle;
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            this.m_VehicleStatus = i_VehicleStatus;
        }

        public string OwnerName
        {
            get => m_OwnerName;
        }

        public string OwnerPhoneNumber
        {
            get => m_OwnerPhoneNumber;
        }

        public Vehicle Vehicle
        {
            get => m_Vehicle;
        }

        public eVehicleStatus VehicleStatus
        {
            get => m_VehicleStatus;
            set => m_VehicleStatus = value;
        }
    }
}
