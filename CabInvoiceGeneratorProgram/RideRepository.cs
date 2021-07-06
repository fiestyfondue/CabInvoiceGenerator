using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiInvoiceGenerator
{
    class RideRepository
    {//Dictionary to store UserId and Rides in list
        Dictionary<string, List<Ride>> userRides = null;

        //Constructor to create Dictionary
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        //Function to add Ride List to specified UserId
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabinvoiceException)
            {
                throw new CabinvoiceException(CabinvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Rides are null");
            }
        }
        //Function to get rides as an array list as an array for specified UserId
        public Ride[] GetRides(string UserId)
        {
            try
            {
                return this.userRides[UserId].ToArray();
            }
            catch(Exception)
            {
                throw new CabinvoiceException(CabinvoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserId");
            }
        }
    }
}
