using System;

namespace TaxiInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to cab invoice Generator");
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL);
            invoice.CalculateFare(2.0, 5);
            
        }
    }
}
