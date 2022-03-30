namespace Vehicles
{
    public abstract class BaseVehicle : IVehicle
    {

        protected static List<IVehicle> VehiclesList { get; private set; } = new List<IVehicle>();
        protected static int VehicleCounter { get; set; } = 0;
        public string Name { get; protected set; } = String.Empty;
        public int ID { get; protected set; }
        public int Speed { get; protected set; }
        public int MinimumSpeed { get; protected set; }
        public int MaximumSpeed { get; protected set; }
        public Environment Environment { get; protected set; } = Environment.land;
        public VehicleState VehicleState { get; protected set; } = VehicleState.stationary;
        public Engine? Engine { get; protected set; }

        public static int Convert(int speed, Environment convertFrom, Environment convertTo)
        {
            if (convertFrom == Environment.land && convertTo == Environment.air) { return speed * 1000 / 3600; }
            if (convertFrom == Environment.air && convertTo == Environment.land) { return speed * 3600 / 1000; }
            if (convertFrom == Environment.land && convertTo == Environment.water) { return speed * 1000 / 1852; }
            if (convertFrom == Environment.water && convertTo == Environment.land) { return speed * 1852 / 1000; }
            throw new ArgumentException("Cannot convert based on given arguments!");
        }
        public static void GetVehiclesList()
        {
            foreach (var vehicle in VehiclesList) Console.WriteLine(vehicle.ToString());
        }
        public void SpeedUp(int speed)
        {
            if (VehicleState == VehicleState.moving)
            {
                Speed += speed;
                if (Speed > MaximumSpeed) Speed = MaximumSpeed;
                Console.WriteLine(Name + "'s speed is now: " + Speed);
            }
            else Console.WriteLine("Cannot change speed of stationary object! Start the vehicle first.");
        }
        public void SlowDown(int speed)
        {
            if (VehicleState != VehicleState.moving)
            {
                Speed -= speed;
                if (Speed < MinimumSpeed) Speed = MinimumSpeed;
                Console.WriteLine(Name + "'s speed is now: " + Speed);
            }
            else Console.WriteLine("Cannot change speed of stationary object! Start the vehicle first.");
        }
        public void RunVehicle()
        {
            if (VehicleState == VehicleState.stationary)
            {
                VehicleState = VehicleState.moving;
                Speed = MinimumSpeed;
                Console.WriteLine(Name + " is moving now.");
            }
            else Console.WriteLine(Name + " is already moving.");
        }
        public virtual void StopVehicle()
        {
            if (VehicleState == VehicleState.moving)
            {
                VehicleState = VehicleState.stationary;
                Speed = 0;
                Console.WriteLine(Name + " is stationary now.");
            }
            else Console.WriteLine(Name + " is already stationary.");
        }
        private string GetVehicleState()
        {
            string state = string.Empty;
            switch (VehicleState)
            {
                case VehicleState.moving:
                    return "running";
                default:
                    return "stationary";
            }
        }
        private string GetEngineType()
        {
            if (Engine != null)
            {
                switch (Engine.EngineType)
                {
                    case EngineType.electricity:
                        return "electric";
                    case EngineType.oil:
                        return "oil";
                    case EngineType.gas:
                        return "gas";
                    default:
                        return "petrol";
                }
            }
            else return string.Empty;
        }
        public override string ToString()
        {
            
            string environment = string.Empty;
            string unit = string.Empty;
            switch (Environment)
            {
                case Environment.air:
                    environment = "air";
                    unit = "mps";
                    break;
                case Environment.water:
                    environment = "water";
                    unit = "knots";
                    break;
                default:
                    environment = "land";
                    unit = "kmph";
                    break;
            }
            string speed = string.Empty;
            if (VehicleState == VehicleState.moving)
                speed = $"It is moving at speed {Speed}{unit}.";
            string engine = string.Empty;
            if (Engine != null)
                engine = $"{Name} is run by {GetEngineType()} engine. It's power is {Engine.Power}KM. ";
            return $"{ID} – {Name} is {GetVehicleState()} on {environment}. {speed} {engine}";
        }
    }
}