namespace Vehicles
{
    public class AirVehicle : LandVehicle, IAir
    {
        public AirVehicle(string? name = null, Engine? engine = null, int wheels = 3) : base(name, engine, wheels) { }
        public void TakeOff()
        {
            if (Environment == Environment.air)
            {
                Console.WriteLine(Name + " is already in air.");
                return;
            }
            if (VehicleState == VehicleState.stationary)
            {
                Console.WriteLine(Name + " is stationary, thus can't take off! Run the vehicle first.");
                return;
            }
            if ((int)Speed * 1000 / 3600 < 20)
            {
                Console.WriteLine(Name + " is too slow to take off! Speed up first.");
                return;
            }
            Environment = Environment.air;
            MinimumSpeed = 20;
            MaximumSpeed = 200;
            Speed = Convert(Speed, Environment.land, Environment.air);
            if (Speed > MaximumSpeed) Speed = MaximumSpeed;
            else if (Speed < MinimumSpeed) Speed = MinimumSpeed;
            Console.WriteLine(Name + " is in air now.");
        }
        public void Land()
        {
            if (Environment == Environment.land)
            {
                Console.WriteLine(Name + " is already landed.");
                return;
            }
            if (Speed != MinimumSpeed)
            {
                Console.WriteLine(Name + " is too fast to land! Slow down first.");
                return;
            }
            Environment = Environment.land;
            MinimumSpeed = 1;
            MaximumSpeed = 350;
            Speed = Convert(Speed, Environment.air, Environment.land);
            if (Speed > MaximumSpeed) Speed = MaximumSpeed;
            else if (Speed < MinimumSpeed) Speed = MinimumSpeed;
            Console.WriteLine(Name + " is landed now.");
        }
        public override void StopVehicle()
        {
            if (Environment == Environment.air)
            {
                Console.WriteLine(Name + " can't stop, because it's in air! Land first.");
                return;
            }
            base.StopVehicle();
        }
    }
}