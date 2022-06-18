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
            Ride ride = new Ride(distance, time);
            Assert.AreEqual(expected, getMethod.CalculateFare(ride));
        }
        [Test]
        public void GivenMultipleRideData_ShouldReturnExpectedTotalFare()
        {
            double expected = 325;
            InvoiceGenerator getMethod = new InvoiceGenerator();
            Ride[] ride = { new Ride(10, 10), new Ride(10, 5), new Ride(10, 10) };
            var result = getMethod.MultipleRides(ride);
            Assert.AreEqual(expected, result.totalFare);
        }
        [Test]
        public void GivenMultipleRideData_ShouldReturnExpectedTotalFare_numberOfRides_AverageFare()
        {
            InvoiceGenerator getMethod = new InvoiceGenerator();
            Ride[] ride = { new Ride(10, 10), new Ride(10, 5), new Ride(10, 10) };
            double totalFare = 325, numberOfRides = ride.Length, averageFare = totalFare / numberOfRides;
            var result = getMethod.MultipleRides(ride);
            Assert.AreEqual(totalFare, result.totalFare);
            Assert.AreEqual(averageFare, result.averageFare);
            Assert.AreEqual(numberOfRides, result.numberOfRides);
        }
        [Test]
        public void GivenUserID_ShouldReturnExpectedTotalFare_numberOfRides_AverageFare()
        {
            RideRepository rideRepository = new RideRepository();
            Ride[] ride = { new Ride(10, 10), new Ride(10, 5), new Ride(10, 10) };
            double totalFare = 325, numberOfRides = ride.Length, averageFare = totalFare / numberOfRides;
            rideRepository.AddRides("harini", ride);
            var result = rideRepository.UserInvoice("harini");
            Assert.AreEqual(totalFare, result.totalFare);
            Assert.AreEqual(averageFare, result.averageFare);
            Assert.AreEqual(numberOfRides, result.numberOfRides);
        }
    }
}
