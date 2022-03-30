using Vehicles;

public static class Program
{
    public static void Main()
    {
        Console.ReadLine();

        AirVehicle vehicle = new AirVehicle("Cycek", new Engine(100, EngineType.petrol));
        vehicle.RunVehicle();
        vehicle.SpeedUp(300);
        vehicle.TakeOff();

        BaseVehicle.GetVehiclesList();
    }
}