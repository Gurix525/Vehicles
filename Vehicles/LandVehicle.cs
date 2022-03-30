namespace Vehicles
{
    public class LandVehicle : BaseVehicle, ILand
    {
        public int Wheels { get; private set; }

        public LandVehicle(string? name = null, Engine? engine = null, int wheels = 4)
        {
            ID = VehicleCounter;
            if (name == null) Name = "Vehicle_" + ID;
            else Name = name;
            if (engine != null) Engine = engine;
            Environment = Environment.land;
            MinimumSpeed = 1;
            MaximumSpeed = 350;
            Wheels = wheels;
            VehicleCounter++;
            VehiclesList.Add(this);
        }
        public override string ToString()
        {
            return base.ToString() + $" {Name} has {Wheels} wheels. ";
        }
    }
}