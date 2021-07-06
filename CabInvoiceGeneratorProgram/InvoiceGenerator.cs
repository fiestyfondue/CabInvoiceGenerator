using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiInvoiceGenerator
{
    public class InvoiceGenerator
    {
        //Variable
        RideType rideType;
        private RideRepository rideRepository;
        //Constants
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;
        //Constructor to create RideRepository instance
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                //If ride is premium then rates set for premium else normal
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch
            {
                throw new CabinvoiceException(CabinvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride Type");
            }
        }
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                //Calculating total fare
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabinvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabinvoiceException(CabinvoiceException.ExceptionType.INVALID_RIDE_TYPE, "INVALID RIDE TYPE");
                }
                if (distance <= 0)
                {
                    throw new CabinvoiceException(CabinvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if (time < 0)
                {
                    throw new CabinvoiceException(CabinvoiceException.ExceptionType.INVALID_TIME, "Invalid time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
    }
}
