using NUnit.Framework;
using TaxiInvoiceGenerator;

namespace CabInvoiceGeneratorTests
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        [Test]
        public void GivenDistanceAndTime_shouldReturn_TotalFare()
        {
            //Creating instance of Invoice Generator for normal rides
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            //Calculating fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            //Asserting Values
            Assert.AreEqual(expected,fare);
        }
    }
}