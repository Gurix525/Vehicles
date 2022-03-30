namespace Vehicles
{
    public abstract class BaseVehicle : IVehicle
    {
        private static List<IVehicle> _vehiclesList = new List<IVehicle>();
        private static int _vehicleCounter = 0;
        private string _name = string.Empty;
        private int _ID = 0;
        private int _speed = 0;
        private int _minimumSpeed = 0;
        private int _maximumSpeed = 0;
        private Environment _environment;
        private VehicleState _vehicleState = VehicleState.stationary;
        private Engine? _engine;

        protected static List<IVehicle> VehiclesList { get => _vehiclesList; set => _vehiclesList = value; }
        protected static int VehicleCounter { get => _vehicleCounter; set => _vehicleCounter = value; }
        public string Name { get => _name; protected set => _name = value; }
        public int ID { get => _ID; protected set => _ID = value; }
        public int Speed { get => _speed; protected set => _speed = value; }
        public int MinimumSpeed { get => _minimumSpeed; protected set => _minimumSpeed = value; }
        public int MaximumSpeed { get => _maximumSpeed; protected set => _maximumSpeed = value; }
        public Environment Environment { get => _environment; protected set => _environment = value; }
        public VehicleState VehicleState { get => _vehicleState; protected set => _vehicleState = value; }
        public Engine? Engine { get => _engine; protected set => _engine = value; }

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
        public override string ToString()
        {
            string state = string.Empty;
            switch (VehicleState)
            {
                case VehicleState.moving: state = "running";
                    break;
                default: state = "stationary";
                    break;
            }
            string environment = string.Empty;
            string unit = string.Empty;
            switch (Environment)
            {
                case Environment.air: environment = "air";
                    unit = "mps";
                    break;
                case Environment.water: environment = "water";
                    unit = "knots";
                    break;
                default: environment = "land";
                    unit = "kmph";
                    break;
            }
            string speed = string.Empty;
            if (VehicleState == VehicleState.moving)
                speed = $"It is moving at speed {Speed}{unit}.";
            string engine = string.Empty;
            string engineType = string.Empty;
            if (Engine != null)
            {
                switch (Engine.EngineType)
                {
                    case EngineType.electricity:
                        engineType = "electric";
                        break;
                    case EngineType.oil:
                        engineType = "oil";
                        break;
                    case EngineType.gas:
                        engineType = "gas";
                        break;
                    default:
                        engineType = "petrol";
                        break;
                }
                engine = $"{Name} is run by {engineType} engine. It's power is {Engine.Power}KM. ";
            }
            return $"{ID} – {Name} is {state} on {environment}.{speed} {engine}";
        }
    }
}