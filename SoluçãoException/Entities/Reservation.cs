using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleSolutionException.Entities.Exceptions;


namespace ExampleSolutionException.Entities
{
    internal class Reservation
    {
        public int RoomNumber { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public Reservation() { }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            DateException(checkIn, checkOut);
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }



        public int Duration()
        {

            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        
            
        }
        public void UpdateDates( DateTime checkIn, DateTime checkOut )
        {
            UpdateException(checkIn, checkOut);
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        private void DateException(DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainException("Check-out date must be after check-in date.");
            }
        }

        private void UpdateException(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn < CheckIn)
            {
                throw new DomainException("The new check-in date must be after the olds check-in date.");
            }
            DateException(checkIn, checkOut);

        }



        public void DisplayInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Reservation: ");
            Console.WriteLine($"Room: {RoomNumber}");
            Console.WriteLine($"Check-In: {CheckIn:d} ");
            Console.WriteLine($"Check-Out: {CheckOut:d} ");
            Console.WriteLine($"Duration: {Duration()} nights");
        }


    }
}
