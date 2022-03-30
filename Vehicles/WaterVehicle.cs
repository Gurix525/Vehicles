namespace Vehicles
{
    public class WaterVehicle : BaseVehicle, IWater
    {
        public int Displacement { get; private set; }

        public WaterVehicle(string? name = null, Engine? engine = null, int displacement = 1)
        {
            ID = VehicleCounter;
            if (name == null) Name = "Vehicle_" + ID;
            else Name = name;
            if (engine != null)
            {
                Engine = engine;
                engine.EngineType = EngineType.oil;
            }
            Environment = Environment.water;
            MinimumSpeed = 1;
            MaximumSpeed = 40;
            Displacement = displacement;
            VehicleCounter++;
            VehiclesList.Add(this);
        }
        public override string ToString()
        {
            return base.ToString() + $"{Name}'s displacement is {Displacement} tons.";
        }
    }
}