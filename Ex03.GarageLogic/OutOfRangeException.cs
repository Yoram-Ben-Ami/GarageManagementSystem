using System;
using System.Runtime.Serialization;

namespace Ex03.GarageLogic
{
    public class OutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        public OutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue) : base(String.Format("Value out of range. The range is: {0} - {1}", i_MinValue, i_MaxValue), i_InnerException)
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }
        public float MinValue
        {
            get { return m_MinValue; }
        }

        public float MaxValue
        {
            get { return m_MaxValue; }
        }
    }
}