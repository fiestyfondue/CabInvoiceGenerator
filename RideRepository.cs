using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class RideRepository
    {//Dictionary to store UserId and Rides into list
        //Constructor to create Dictionary
        Dictionary<string, List<Ride>> userRides = null;
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>(); //Initializing Dictionary

        }
        public void AddRide(string userId,Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if(!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch(InvoiceCustomException)
            {
                throw new InvoiceCustomException(InvoiceCustomException.ErrorType.PARAMETERS_DOESNT_MEET_REQUIREMENTS, "Rides are null");
            }
        }
        public Ride[] GetRides(string userId) //Function to get Rides as an array for Specified UserId
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch(Exception)
            {
                throw new InvoiceCustomException(InvoiceCustomException.ErrorType.NO_SUCH_TYPE, "Invalid User Id");
            }
        }
    }
}
