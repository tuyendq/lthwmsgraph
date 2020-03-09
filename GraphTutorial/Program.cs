using System;

namespace GraphTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".NET Core Graph Tutorial\n");

            int choice = -1;

            while (choice != 0) {
                System.Console.WriteLine("Please choose one of the following options:");
                System.Console.WriteLine("0. Exit");
                System.Console.WriteLine("1. Display access token");
                System.Console.WriteLine("2. List calendar events");

                try {
                    choice = int.Parse(Console.ReadLine());

                } catch (System.FormatException){
                    // Set to invalid value
                    choice = -1;
                }

                switch(choice) {
                    case 0:
                        // Exit program
                        System.Console.WriteLine("Bye...");
                        break;
                    case 1:
                        // Display access token
                        break;
                    case 2:
                        // List calendar
                        break;
                    default:
                        System.Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
    }
}
