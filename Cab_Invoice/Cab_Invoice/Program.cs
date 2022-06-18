// See https://aka.ms/new-console-template for more information
using Cab_Invoice;



using System;

namespace CabInvoice
{
    public class Program
    {
        public static void Main(string[] args)
        
        {
                 InvoiceGenerator getMethod = new InvoiceGenerator();

                Console.WriteLine("1 for Total Fare\n2 for Multiple Rides\n3 for Enhanced Invoice\n4 for Invoice for UserID");
                Console.WriteLine("Enter a Number");
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        {
                            double distance = 10;
                            int time = 10;
                            Ride ride = new Ride(distance, time);
                            double result = getMethod.CalculateFare(ride);
                            Console.WriteLine("Total Fare: " + result);
                            break;
                        }
                    case 2:
                        {
                            Ride[] ride = { new Ride(10, 10), new Ride(10, 5), new Ride(10, 10) };
                            EnhancedInvoice result = getMethod.MultipleRides(ride);
                            Console.WriteLine("Total Fare for Multiple Rides:" + result.totalFare);
                            break;
                        }
                    case 3:
                        {
                            Ride[] ride = { new Ride(10, 10), new Ride(10, 5), new Ride(10, 10) };
                            EnhancedInvoice invoice = getMethod.MultipleRides(ride);
                            Console.WriteLine("TotalFare: " + invoice.totalFare + "\nNumberOfRides: " + invoice.numberOfRides + "\nAverage Fare: " + invoice.averageFare);
                            break;
                        }
                    case 4:
                        {
                            RideRepository rideRepository = new RideRepository();
                            Ride[] harini = { new Ride(10, 10), new Ride(10, 20), new Ride(10, 10) };
                            rideRepository.AddRides("Harini", harini);
                            Ride[] harshi = { new Ride(30, 10), new Ride(10, 5), new Ride(10, 20) };
                            rideRepository.AddRides("Harshini", harshi);
                            var invoice = rideRepository.UserInvoice("Harini");
                            Console.WriteLine("TotalFare: " + invoice.totalFare + "\nNumberOfRides: " + invoice.numberOfRides + "\nAverage Fare: " + invoice.averageFare);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter a Valid Number");
                            break;
                        }
                }

            }
        }
    }