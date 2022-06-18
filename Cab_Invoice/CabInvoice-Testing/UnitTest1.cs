using Cab_Invoice;

namespace CabInvoice_Testing
{
    public class Tests
    {
        [Test]
        public void GivenDistanceAndTime_ShouldReturnExpectedTotalFare()
        {
            double distance = 10;
            int time = 10, expected = 110;
            InvoiceGenerator getMethod = new InvoiceGenerator();
            Cab_Invoice.Ride ride = new Cab_Invoice.Ride(distance, time);
            Assert.AreEqual(expected, getMethod.CalculateFare(ride));
        }
        [Test]
        public void GivenMultipleRideData_ShouldReturnExpectedTotalFare()
        {
            int expected = 215;
            InvoiceGenerator getMethod = new InvoiceGenerator();
            Ride[] ride = { new Ride(10, 10), new Ride(10, 5) };
            Assert.AreEqual(expected, getMethod.MultipleRides(ride));
        }
        [Test]
        public void GivenMultipleRideData_ShouldReturnExpectedTotalFare_numberOfRides_AverageFare()
        {
            InvoiceGenerator getMethod = new InvoiceGenerator();
            Ride[] ride = { new Ride(10, 10), new Ride(10, 5), new Ride(10, 10) };
            double totalFate = 325, numberOfRides = ride.Length, averageFare = totalFate / numberOfRides;
            EnhancedInvoice result = getMethod.CalculateMultipleRides(ride);
            Assert.AreEqual(totalFate, result.totalFare);
            Assert.AreEqual(averageFare, result.averageFare);
            Assert.AreEqual(numberOfRides, result.numberOfRides);
        }
    }
}
