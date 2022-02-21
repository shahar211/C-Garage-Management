namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class GarageOpreations
    {
        private readonly List<CarOwnerDetails> r_OwnerDetailsInGarage;

        public List<CarOwnerDetails> OwnerDetailsInGarage
        {
            get
            {
                return r_OwnerDetailsInGarage;
            }
        }

        public GarageOpreations()
        {
            r_OwnerDetailsInGarage = new List<CarOwnerDetails>();
        }

        public List<string> DisplayLicenseNumber(int i_EnumTypeInInt)
        {
            List<string> licenseNumberList = new List<string>();
            if (i_EnumTypeInInt == Enum.GetNames(typeof(eStateCar)).Length)
            {
                foreach(CarOwnerDetails carOwnerDetails in r_OwnerDetailsInGarage)
                {
                    licenseNumberList.Add(carOwnerDetails.VehicleInGarage.LicenseNumber);
                }
            }
            else
            {
                eStateCar carState = (eStateCar)eStateCar.ToObject(
                    typeof(eStateCar), i_EnumTypeInInt);
                foreach (CarOwnerDetails carOwnerDetails in r_OwnerDetailsInGarage)
                {
                    if(carOwnerDetails.eCarState == carState)
                    {
                        licenseNumberList.Add(carOwnerDetails.VehicleInGarage.LicenseNumber);
                    }
                }
            }

            return licenseNumberList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eStateCar i_StateCar)
        {
            CarOwnerDetails singleCarOwnerDetail = GetCarOwnerDetailsByLicense(i_LicenseNumber);
            singleCarOwnerDetail.eCarState = i_StateCar;
        }

        public CarOwnerDetails GetCarOwnerDetailsByLicense(string i_LicenseNumber)
        {
            CarOwnerDetails vehicleToReturn = null;
            foreach (CarOwnerDetails singleCarOwnerDetail in r_OwnerDetailsInGarage)
            {
                if (singleCarOwnerDetail.VehicleInGarage.LicenseNumber == i_LicenseNumber)
                {
                    vehicleToReturn = singleCarOwnerDetail;
                    break;
                }
            }

            if(vehicleToReturn == null)
            {
                throw new FormatException(string.Format("The license do not exists"));
            }

            return vehicleToReturn;
        }

        public bool CheckIfVehicleExists(string i_LicenseNumber)
        {
            bool isExsits = false;

            foreach (CarOwnerDetails singleCarOwnerDetail in r_OwnerDetailsInGarage)
            {
                if (singleCarOwnerDetail.VehicleInGarage.LicenseNumber == i_LicenseNumber)
                {
                    isExsits = true;
                    break;
                }
            }

            return isExsits;
        }

        public void FillAirInWheelsToMax(string i_LicenseNumber)
        {
            CarOwnerDetails singleCarOwnerDetail = GetCarOwnerDetailsByLicense(i_LicenseNumber);
            List<Wheel> listWheels = singleCarOwnerDetail.VehicleInGarage.ListWheels;
            
            foreach(Wheel wheel in listWheels)
            {
                float airPressureToAdd = wheel.MaxAirPressure - wheel.CurrentAirPressure;

                wheel.AddAirPressureToWheel(airPressureToAdd);
            }
        }

        public void ReFuelVehicle(string i_LicenseNumber, float i_AmountToFuel, eFuelType i_FuelType)
        {
            CarOwnerDetails singleCarOwnerDetail = GetCarOwnerDetailsByLicense(i_LicenseNumber);
            Vehicle vehicle = singleCarOwnerDetail.VehicleInGarage;
            FueledVehicle fueledVehicle = vehicle.EngineType as FueledVehicle;

            if(fueledVehicle != null)
            {
                fueledVehicle.ReFuel(i_AmountToFuel, i_FuelType);
            }
            else
            {
                throw new FormatException(string.Format("The vehicle is not fuel type"));
            }
        }

        public void ReChargeVehicle(string i_LicenseNumber, float i_BatteryAmountToChargeInMinutes)
        {
            CarOwnerDetails singleCarOwnerDetail = GetCarOwnerDetailsByLicense(i_LicenseNumber);
            Vehicle vehicle = singleCarOwnerDetail.VehicleInGarage;
            ElectricVehicle electricVehicle = vehicle.EngineType as ElectricVehicle;

            if (electricVehicle != null)
            {
                electricVehicle.ReChargeBattery(i_BatteryAmountToChargeInMinutes / 60);
            }
            else
            {
                throw new FormatException(string.Format("The Vehicle is not Electric Type"));
            }
        }

        public string DisplayCarInfo(string i_LicenseNumber)
        {
            CarOwnerDetails singleCarOwnerDetail = GetCarOwnerDetailsByLicense(i_LicenseNumber);

            return singleCarOwnerDetail.ToString();
        }
    }
}
