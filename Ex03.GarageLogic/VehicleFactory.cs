namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private const int k_MaxCarAirPressure = 30;
        private const int k_MaxMotorCycleAirPressure = 29;
        private const int k_MaxTruckAirPressure = 25;
        private const int k_MotorCycleAmountWheels = 2;
        private const int k_TruckAmountWheels = 16;
        private const int k_CarAmountWheels = 4;

        public static Vehicle CreateNewVehicleType(eVehicleType i_TypeOfCar)
        {
            Vehicle vehicle = null;

            switch (i_TypeOfCar)
            {
                case eVehicleType.ElectricMotorCycle:
                    ElectricVehicle electricEngineMotorCycle = new ElectricVehicle((float)2.3);
                    MotorCycle electricMotorCycle = new MotorCycle(k_MotorCycleAmountWheels, k_MaxMotorCycleAirPressure, electricEngineMotorCycle);

                    vehicle = electricMotorCycle as Vehicle;
                    break;
                case eVehicleType.FueledMotorCycle:
                    FueledVehicle fueledEngineMotorCycle = new FueledVehicle((float)5.8, eFuelType.Octan98);
                    MotorCycle fueledMotorCycle = new MotorCycle(k_MotorCycleAmountWheels, k_MaxMotorCycleAirPressure, fueledEngineMotorCycle);

                    vehicle = fueledMotorCycle as Vehicle;
                    break;
                case eVehicleType.ElectricCar:
                    ElectricVehicle electricEngineCar = new ElectricVehicle((float)2.6);
                    Car electricCar = new Car(k_CarAmountWheels, k_MaxCarAirPressure, electricEngineCar);

                    vehicle = electricCar as Vehicle;
                    break;
                case eVehicleType.FueledCar:
                    FueledVehicle fueledEngineCar = new FueledVehicle(48, eFuelType.Octan95);
                    Car fueledCar = new Car(k_CarAmountWheels, k_MaxCarAirPressure, fueledEngineCar);

                    vehicle = fueledCar as Vehicle;
                    break;
                case eVehicleType.Truck:
                    FueledVehicle fueledEngineTruck = new FueledVehicle(130, eFuelType.Soler);
                    Truck truck = new Truck(k_TruckAmountWheels, k_MaxTruckAirPressure, fueledEngineTruck);

                    vehicle = truck as Vehicle;
                    break;
            }

            return vehicle;
        }
    }
}
