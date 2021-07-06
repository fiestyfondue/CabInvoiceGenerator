using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiInvoiceGenerator
{
    class CabinvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            NULL_RIDES,
            INVALID_USER_ID,
            INVALID_TIME
        }
        ExceptionType type;
        //Parameter Constructor for setting Exception Type and throwing exception
        public CabinvoiceException(ExceptionType type,string message) : base(message)
        {
            this.type = type;
        }
    }
}
