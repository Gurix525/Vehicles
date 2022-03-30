namespace Vehicles
{
    public class Engine
    {
        private int _power;
        private EngineType _engineType;

        public int Power { get => _power; set => _power = value; }
        public EngineType EngineType { get => _engineType; set => _engineType = value; }

        public Engine(int power, EngineType engineType)
        {
            Power = power;
            EngineType = engineType;
        }
    }
}