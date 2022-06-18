using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice
{

    public class InvoiceGenerator
    {
        
        RideRepository data;
        private readonly double MINIMUM_COST_PER_KM = 10;
        private readonly int COST_PER_TIME = 1;
        private readonly double MINIMUM_FARE = 5;
        public double CalculateFare(Ride ride)
        {
            double totalFare = 0;
            if (ride.distance >= 0 && ride.time >= 0)
            {
                totalFare = ride.distance * MINIMUM_COST_PER_KM + ride.time * COST_PER_TIME;
            }
            else
            {
                if (ride.distance <= 0)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (ride.time < 0)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
        public EnhancedInvoice MultipleRides(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach (var ride in rides)
                {
                    totalFare += CalculateFare(ride);
                }
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_RIDES, "Rides Are Null");
            }
            return new EnhancedInvoice(rides.Length, totalFare);
        }

    }
}


