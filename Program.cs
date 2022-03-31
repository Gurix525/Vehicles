using Vehicles;

public static class Program
{
    public static void Main()
    {
        Console.ReadLine();

        LandVehicle polonez = new LandVehicle("Polonez1", new Engine(100, EngineType.petrol));
        LandVehicle polonez2 = new LandVehicle("Polonez1", new Engine(80, EngineType.gas));
        LandVehicle polonez3 = new LandVehicle("Polonez1", new Engine(250, EngineType.oil));
        LandVehicle polonez4 = new LandVehicle("Polonez1", new Engine(20, EngineType.electricity));
        LandVehicle polonez5 = new LandVehicle("Polonez1", new Engine(945, EngineType.petrol));

        WaterVehicle statek = new WaterVehicle("Statek1", new Engine(80, EngineType.petrol));
        WaterVehicle statek2 = new WaterVehicle("Statek2", new Engine(100, EngineType.oil));
        WaterVehicle statek3 = new WaterVehicle("Statek3", new Engine(400, EngineType.gas));

        AirVehicle air = new AirVehicle("Samolot1", new Engine(100, EngineType.petrol));
        AirVehicle air2 = new AirVehicle("Samolot2", new Engine(478, EngineType.electricity));
        AirVehicle air3 = new AirVehicle("Samolot3", new Engine(999, EngineType.oil));

        AmphibiacVehicle amphibiac = new AmphibiacVehicle("Amphibia1", new Engine(100, EngineType.petrol));
        AmphibiacVehicle amphibiac2 = new AmphibiacVehicle("Amphibia1", new Engine(98, EngineType.oil));

        air.RunVehicle();
        air.SpeedUp(400);
        air.TakeOff();
        air.SlowDown(1000);

        air3.RunVehicle();
        air3.SpeedUp(400);
        air3.TakeOff();
        air3.SpeedUp(1000);

        statek.RunVehicle();
        statek.SpeedUp(40);

        statek2.RunVehicle();
        

        polonez2.RunVehicle();
        polonez3.RunVehicle();

        polonez2.SpeedUp(100);
        polonez3.SpeedUp(200);

        polonez5.RunVehicle();
        polonez5.SpeedUp(20);

        amphibiac.RunVehicle();
        amphibiac.Swim();
        amphibiac.SpeedUp(20);

        BaseVehicle.GetVehiclesList();
        //BaseVehicle.GetVehiclesByTypeImplicit<IAir>();
        //BaseVehicle.GetLandVehicles();
        //BaseVehicle.GetVehiclesBySpeedAscending();
        //BaseVehicle.GetLandVehiclesBySpeedDescending();
        //BaseVehicle.GetVehiclesByTypeExplicit<ILand>();
        //BaseVehicle.GetVehiclesByTypeExplicit<IAir>();
        //BaseVehicle.GetVehiclesByTypeExplicit<IWater>();
        //BaseVehicle.GetVehiclesByTypeExplicit<IAmphibiac>();
    }
}