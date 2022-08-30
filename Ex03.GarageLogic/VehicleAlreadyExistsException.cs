using System;
using System.Runtime.Serialization;

namespace Ex03.GarageLogic
{
    public class VehicleAlreadyExistsException : Exception
    {
        private string m_LicenseNumber;

        public VehicleAlreadyExistsException(Exception i_InnerException, string i_LicenseNumber) : base(String.Format("Vehicle ({0}) already exists in the garage. Status changed to 'In repair'", i_LicenseNumber), i_InnerException)
        {
            this.m_LicenseNumber = i_LicenseNumber;
        }
    }
}