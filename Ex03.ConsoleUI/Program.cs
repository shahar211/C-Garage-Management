namespace Ex03.ConsoleUI
{
    using System;

    public class Program
    {
        public static void Main()
        {
            CarOwnerController carOwnerController = new CarOwnerController(); 

            carOwnerController.Start();
            Console.ReadLine();
        }
    }
}
