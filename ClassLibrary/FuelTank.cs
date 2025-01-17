namespace ClassLibrary
{
    public class FuelTank
    {
        public string FuelType { get; set; }
        public double Capacity { get; set; }
        public double CurrentLevel { get; set; }

        public FuelTank(string fuelType, double capacity) 
        {
            Capacity = capacity;
            FuelType = fuelType;
            CurrentLevel = capacity / 2;
        }

        public void AddFuel(double amount)
        {
            CurrentLevel += amount;

            Console.WriteLine($"Added {amount} litters to the tank");
        }

        public void RemoveFuel(double amount)
        {
            CurrentLevel -= amount;

            Console.WriteLine($"Removed {amount} litters to the tank");
        }
    }
}
