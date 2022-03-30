namespace Vehicles
{
    public interface IVehicle
    {
        protected int ID { get; }
        protected string Name { get; }
        protected int Speed { get; }
        protected int MinimumSpeed { get; }
        protected int MaximumSpeed { get; }
        protected Environment Environment { get; }
        protected VehicleState VehicleState { get; }
        protected Engine? Engine { get; }
        protected void RunVehicle();
        protected void StopVehicle();
        protected void SpeedUp(int speed);
        protected void SlowDown(int speed);
    }
}