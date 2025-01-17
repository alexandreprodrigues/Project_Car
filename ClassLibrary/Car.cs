namespace Classes
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double Weight { get; set; }
        public Engine Engine { get; set; }
        public FuelTank FuelTank { get; set; }

        public Car(string brand, string model, string color, double weight, Engine engine, FuelTank fuelTank)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Weight = weight;
            Engine = engine;
            FuelTank = fuelTank;
        }

        public void StartEngine()
        {
            if (!Engine.IsRunning)
            {
                Engine.TurnOn();
            }
        }

        public void StopEngine()
        {
            if (Engine.IsRunning)
            {
                Engine.TurnOff();
            }

        }
    }
}
