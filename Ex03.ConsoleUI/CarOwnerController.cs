namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using Ex03.GarageLogic;

    public class CarOwnerController
    {
        private readonly GarageOpreations r_GarageOpreations;

        public CarOwnerController()
        {
            r_GarageOpreations = new GarageOpreations();
        }

        public void Start()
        {
            Console.WriteLine("Hello Welcome to S.O Garage");
            garageOpreationsHandler();
        }

        private void createNewCustomer()
        {
            string message = string.Format(
                @"we need you to enter details about you and your vehicle.");
            Console.WriteLine(message);
            Vehicle vehicle = VehicleInitialization.GetVehicleTypeFromUser();

            if (r_GarageOpreations.CheckIfVehicleExists(vehicle.LicenseNumber))
            {
                Console.WriteLine("Vehicle already in garage, his status will be changed to in repair");
                r_GarageOpreations.ChangeVehicleStatus(vehicle.LicenseNumber, eStateCar.InRepair);
            }
            else
            {
                Console.WriteLine("Please Enter Your Full name");
                string clientFullName = ValidationInput.CheckStringInputLength();

                Console.WriteLine("Please Enter Your Phone Number");
                string clientPhoneNumber = ValidationInput.CheckStringInputLength();

                r_GarageOpreations.OwnerDetailsInGarage.Add(
                    new CarOwnerDetails(clientFullName, clientPhoneNumber, eStateCar.InRepair, vehicle));
            }
        }

        private void printVehiclesByStatus()
        {
            string message = string.Format(
                @"If you want to filter the list by vehicle status in the garage enter number, between 0-{0} 
from the list: {1}
and if you do not want , enter the number {2}",
                Enum.GetNames(typeof(eStateCar)).Length - 1,
                string.Join(", ", Enum.GetNames(typeof(eStateCar))), 
                Enum.GetNames(typeof(eStateCar)).Length);

            Console.WriteLine(message);
            int userCarStateIntInput =
                ValidationInput.CheckIfUserIntNumberInRange(Enum.GetNames(typeof(eStateCar)).Length);
            List<string> listLicenseNumberToPresent = r_GarageOpreations.DisplayLicenseNumber(userCarStateIntInput);

            if(listLicenseNumberToPresent.Count == 0)
            {
                message = string.Format(@"No vehicles to display {0}", Environment.NewLine);
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("The vehicles are:");
            }

            foreach(string licenseNumber in listLicenseNumberToPresent)
            {
                Console.WriteLine(licenseNumber);
            }
        }

        private void changeVehicleByStatus()
        {
            string message = string.Format(
                @"enter new car status, between 0-{0} 
from the list: {1}",
                Enum.GetNames(typeof(eStateCar)).Length - 1,
                string.Join(", ", Enum.GetNames(typeof(eStateCar))));

            Console.WriteLine(message);
            int userCarStateIntInput =
                ValidationInput.CheckIfUserIntNumberInRange(Enum.GetNames(typeof(eStateCar)).Length - 1);
            eStateCar userStateCarInput = (eStateCar)eStateCar.ToObject(
                typeof(eStateCar), userCarStateIntInput);

            Console.WriteLine("enter license number");
            string licenseNumber = ValidationInput.CheckStringInputLength();

            r_GarageOpreations.ChangeVehicleStatus(licenseNumber, userStateCarInput);
            message = string.Format(
                @"Status has been updated to :{0}{1}",
                userStateCarInput.ToString(),
                Environment.NewLine);
            Console.WriteLine(message);
        }

        private void userFuelInput()
        {
            Console.WriteLine("enter license number");
            string licenseNumber = ValidationInput.CheckStringInputLength();
            r_GarageOpreations.GetCarOwnerDetailsByLicense(licenseNumber);

            string message = string.Format(
                @"Enter Fuel Type, between 0-{0} 
from the list: {1}",
                Enum.GetNames(typeof(eFuelType)).Length - 1,
                string.Join(", ", Enum.GetNames(typeof(eFuelType))));

            Console.WriteLine(message);
            int userCarStateIntInput =
                ValidationInput.CheckIfUserIntNumberInRange(Enum.GetNames(typeof(eFuelType)).Length);
            eFuelType userFuelTypeInput = (eFuelType)eFuelType.ToObject(
                typeof(eFuelType), userCarStateIntInput);

            Console.WriteLine("enter amount to fuel");
            float amountToFuelInFloat = ValidationInput.GetVariable<float>();

            r_GarageOpreations.ReFuelVehicle(licenseNumber, amountToFuelInFloat, userFuelTypeInput);
            Console.WriteLine("The vehicle has been fueled");
        }

        private void userElectricChargeInput()
        {
            Console.WriteLine("enter license number");
            string licenseNumber = ValidationInput.CheckStringInputLength();

            r_GarageOpreations.GetCarOwnerDetailsByLicense(licenseNumber);
            Console.WriteLine("Please Enter Energy Amount To Charge");
            float energyAmountToCharge = ValidationInput.GetVariable<float>();

            r_GarageOpreations.ReChargeVehicle(licenseNumber, energyAmountToCharge);
            Console.WriteLine("The vehicle has been charged");
        }

        private void garageOpreationsHandler()
        {
            int userInputChoise = 0;
            bool keepProgramRuning = true;

            while (keepProgramRuning)
            {
                try
                {
                    Console.WriteLine(@"To add new car press 1
To display vehicle licenses in garage press 2
To change vehicle status in garage press 3
To fill Air in wheels to max press 4
To fuel your car press 5
To charge electric car press 6
To display all information about vehicle and his owner press 7
TO EXIT ENTER 0");
                    userInputChoise = ValidationInput.CheckIfUserIntNumberInRange(7);
                    Console.Clear();
                    switch(userInputChoise)
                    {
                        case 1:
                            createNewCustomer();
                            break;
                        case 2: 
                            printVehiclesByStatus();
                            break;
                        case 3:
                            changeVehicleByStatus();
                            break;
                        case 4:
                            Console.WriteLine("enter license number");
                            string licenseNumber = ValidationInput.CheckStringInputLength();
                            r_GarageOpreations.FillAirInWheelsToMax(licenseNumber);
                            Console.WriteLine("All wheels are at max air pressure");
                            break;
                        case 5:
                            userFuelInput();
                            break;
                        case 6:
                            userElectricChargeInput();
                            break;
                        case 7:
                            Console.WriteLine("enter license number");
                            Console.WriteLine(r_GarageOpreations.DisplayCarInfo(Console.ReadLine()));
                            break;
                        default:
                            keepProgramRuning = false;
                            break;
                    }
                }
                catch(Exception e)
                { 
                    catchException(e);
                }
            }
        }

        private void catchException(Exception i_Exception)
        {
            Console.WriteLine(i_Exception.Message);
            string message = string.Format(@"Error! Going back to garage menu {0}", Environment.NewLine);

            Console.WriteLine(message);
            garageOpreationsHandler();
        }
    }
}
