using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiInvoiceGenerator
{
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double totalFare;
        private double averageFare;

        //Parameeter constructor for setting data
        public InvoiceSummary(int numberOfRides , double totalFare)
        {
            //Setting Data
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is InvoiceSummary)) return false;

            InvoiceSummary inputedObject = (InvoiceSummary)obj;
            return this.numberOfRides == inputedObject.numberOfRides && this.totalFare==inputedObject.totalFare && this.averageFare==inputedObject.averageFare;
        }
        //Overriding GetHashCode Method
        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode()^this.totalFare.GetHashCode()^this.averageFare.GetHashCode();
        }
    }
}
