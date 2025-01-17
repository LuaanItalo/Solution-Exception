﻿using ExampleSolutionException.Entities;
using ExampleSolutionException.Entities.Exceptions;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {

            Console.Write("Room Number: ");
            int number = int.Parse(Console.ReadLine()!);
            Console.Write("Check-In date (dd/MM/yyyy): ");
            DateTime chekIn = DateTime.Parse(Console.ReadLine()!);
            Console.Write("Check-Out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine()!);

            var reservation = new Reservation(number, chekIn, checkOut);
            reservation.DisplayInfo();

            Console.WriteLine();
            Console.WriteLine("Enter data to Update the reservation: ");
            Console.Write("Check-In date (dd/MM/yyyy): ");
            chekIn = DateTime.Parse(Console.ReadLine()!);
            Console.Write("Check-Out date (dd/MM/yyyy): ");
            checkOut = DateTime.Parse(Console.ReadLine()!);

            reservation.UpdateDates(chekIn, checkOut);
            reservation.DisplayInfo();

        }
        catch (DomainException e)
        {
            Console.WriteLine($"Error in reservation: {e.Message}");
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Format error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }

    }
}