namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Ex03.GarageLogic;

    public class VehicleInitialization
    {
        public static Vehicle GetVehicleTypeFromUser()
        {
            string message = string.Format(
                @"Please Enter The number of Vehicle Type between 0-{0} 
from the list: {1}",
                Enum.GetNames(typeof(eVehicleType)).Length - 1,
                string.Join(", ", Enum.GetNames(typeof(eVehicleType))));

            Console.WriteLine(message);
            int userCarTypeIntInput = ValidationInput.CheckIfUserIntNumberInRange(Enum.GetNames(typeof(eVehicleType)).Length - 1);
            eVehicleType userVehicleTypeInput = (eVehicleType)eVehicleType.ToObject(
                typeof(eVehicleType), userCarTypeIntInput);
            Vehicle vehicle = VehicleFactory.CreateNewVehicleType(userVehicleTypeInput);

            initialization(vehicle);

            return vehicle;
        }

        private static void initialization(Vehicle i_Vehicle)
        {
            string message;

            initVehicle(i_Vehicle);
            if (i_Vehicle is Car)
            {
                initCar(i_Vehicle);
            }

            if(i_Vehicle is Truck)
            {
                initTruck(i_Vehicle);
            }

            if(i_Vehicle is MotorCycle)
            {
                initMotorCycle(i_Vehicle);   
            }

            message = string.Format(@"Please Enter Current Amount Energy in the engine Amount between 0-{0}", i_Vehicle.EngineType.CountMaxEnergy);
            Console.WriteLine(message);
            float energyAmountRightNow = ValidationInput.CheckIfUserFloatNumberInRange(i_Vehicle.EngineType.CountMaxEnergy);

            i_Vehicle.EngineType.CountEnergyRightNow = energyAmountRightNow;
        }

        private static void initVehicle(Vehicle i_Vehicle)
        {
            string modelName, licenseNumber, wheelModelName, message;
            List<float> listWheelsCurrentAirPresssure = new List<float>();
            float wheelFloatCurrentAirPresssure;

            Console.WriteLine("Enter Vehicle Model Name");
            modelName = ValidationInput.CheckStringInputLength();

            Console.WriteLine("Enter Vehicle License Number");
            licenseNumber = ValidationInput.CheckStringInputLength();

            Console.WriteLine("Enter Wheel Model Name");
            wheelModelName = ValidationInput.CheckStringInputLength();

            for (int i = 0; i < i_Vehicle.AmountWheels; i++)
            {
                message = string.Format(@"Enter Wheel Current Number Air Pressure between 0-{0}", i_Vehicle.ListWheels.ElementAt(i).MaxAirPressure);
                Console.WriteLine(message);
                wheelFloatCurrentAirPresssure = ValidationInput.CheckIfUserFloatNumberInRange(i_Vehicle.ListWheels.ElementAt(i).MaxAirPressure);
                listWheelsCurrentAirPresssure.Add(wheelFloatCurrentAirPresssure);
            }

            i_Vehicle.Init(modelName, licenseNumber, listWheelsCurrentAirPresssure, wheelModelName);
        }

        private static void initMotorCycle(Vehicle i_Vehicle)
        {
            string message = string.Format(
                @"Please Enter number of MotorCycle's License Type between 0-{0} 
from the list: {1}",
                Enum.GetNames(typeof(eLicenseType)).Length - 1,
                string.Join(", ", Enum.GetNames(typeof(eLicenseType))));

            Console.WriteLine(message);
            int driverLicenseInt = ValidationInput.CheckIfUserIntNumberInRange(Enum.GetNames(typeof(eLicenseType)).Length - 1);

            ((MotorCycle)i_Vehicle).LicenseType = (eLicenseType)eLicenseType.ToObject(typeof(eLicenseType), driverLicenseInt);
            Console.WriteLine("Please enter the number of engine capacity");
            ((MotorCycle)i_Vehicle).EngineCapcity = ValidationInput.GetVariable<int>();
        }

        private static void initTruck(Vehicle i_Vehicle)
        {
            Console.WriteLine("Do You want the Truck to Carry Refrigerated contents 1 for yes 0 for no");
            int isCarryingRefrigeratedContent = ValidationInput.CheckIfUserIntNumberInRange(1);
            bool carryRefrigeratedContents = isCarryingRefrigeratedContent.Equals('1') ? true : false;

            ((Truck)i_Vehicle).RefrigeratedContent = carryRefrigeratedContents;
            Console.WriteLine("Please Enter Cargo Volume");
            ((Truck)i_Vehicle).CargoVolume = ValidationInput.GetVariable<float>();
        }

        private static void initCar(Vehicle i_Vehicle)
        {
            string message;

            message = string.Format(
                @"Please Enter The number of Car Color between 0-{0} 
from the list: {1}",
                Enum.GetNames(typeof(eColorType)).Length - 1,
                string.Join(", ", Enum.GetNames(typeof(eColorType))));
            Console.WriteLine(message);
            int numberColorCarPossitionInEnum =
                ValidationInput.CheckIfUserIntNumberInRange(Enum.GetNames(typeof(eColorType)).Length - 1);

            ((Car)i_Vehicle).CarColor = (eColorType)eColorType.ToObject(
                typeof(eColorType),
                numberColorCarPossitionInEnum);

            message = string.Format(
                @"Please Enter The number of Car Door between 0-{0} 
from the list: {1}",
                Enum.GetNames(typeof(eCarDoorsAmount)).Length - 1,
                string.Join(", ", Enum.GetNames(typeof(eCarDoorsAmount))));

            Console.WriteLine(message);
            int numberCarDoorsPossitionInEnum =
                ValidationInput.CheckIfUserIntNumberInRange(Enum.GetNames(typeof(eCarDoorsAmount)).Length - 1);

            ((Car)i_Vehicle).DoorNumber = (eCarDoorsAmount)eCarDoorsAmount.ToObject(
                typeof(eCarDoorsAmount),
                numberColorCarPossitionInEnum);
        }
    }
}
