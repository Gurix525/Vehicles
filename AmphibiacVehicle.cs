namespace Vehicles
{
    public class AmphibiacVehicle : LandVehicle, IWater
    {
        private int _displacement;

        public int Displacement { get => _displacement; set => _displacement = value; }

        public AmphibiacVehicle(string? name = null, Engine? engine = null, int displacement = 1, int wheels = 4) : base(name, engine, wheels)
        {
            if (engine != null)
            {
                Engine = engine;
                engine.EngineType = EngineType.oil;
            }
            Displacement = displacement;
        }
        public void Swim()
        {
            if (Environment == Environment.water)
            {
                Console.WriteLine(Name + " is already swimming.");
                return;
            }
            if (VehicleState == VehicleState.stationary)
            {
                Console.WriteLine(Name + " is stationary, thus can't swim. Run the vehicle first.");
                return;
            }
            Environment = Environment.water;
            MinimumSpeed = 1;
            MaximumSpeed = 40;
            Speed = Convert(Speed, Environment.land, Environment.water);
            if (Speed > MaximumSpeed) Speed = MaximumSpeed;
            else if (Speed < MinimumSpeed) Speed = MinimumSpeed;
            Console.WriteLine(Name + " is on water now.");
        }
        public void Land()
        {
            if (Environment == Environment.land)
            {
                Console.WriteLine(Name + " is already on land.");
                return;
            }
            if (VehicleState == VehicleState.stationary)
            {
                Console.WriteLine(Name + " is stationary, thus can't land. Run the vehicle first.");
                return;
            }
            Environment = Environment.land;
            MinimumSpeed = 1;
            MaximumSpeed = 350;
            Speed = Convert(Speed, Environment.water, Environment.land);
            if (Speed > MaximumSpeed) Speed = MaximumSpeed;
            else if (Speed < MinimumSpeed) Speed = MinimumSpeed;
            Console.WriteLine(Name + " is on land now.");
        }
        public override string ToString()
        {
            return base.ToString() + $"{Name}'s displacement is {Displacement} tons.";
        }
    }
}