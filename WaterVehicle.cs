namespace Vehicles
{
    public class WaterVehicle : BaseVehicle, IWater
    {
        private int _displacement;

        public int Displacement { get => _displacement; set => _displacement = value; }

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