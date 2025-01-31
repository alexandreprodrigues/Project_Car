using Interfaces;

namespace Classes
{
    public class Battery : IEnergySource
    {
        public string Type { get; set; }
        public double Capacity { get; set; }
        public double CurrentLevel { get; set; }

        public Battery(string type, double capacity)
        {
            Capacity = capacity;
            Type = type;
            CurrentLevel = capacity;
        }

        public void Add(double amount)
        {
            if (CurrentLevel + amount > Capacity)
            {
                Console.WriteLine("Cannot charge more than the total capacity of the battery");
            }
            else
            {
                CurrentLevel += amount;

                Console.WriteLine($"Added {amount}% to the battery total. Battery: {CurrentLevel}%.");
            }
        }

        public void Remove(double amount)
        {
            if (CurrentLevel - amount < 0)
            {
                CurrentLevel = 0;
            }
            else
            {
                CurrentLevel -= amount;

                Console.WriteLine($"Removed {amount}% of the battery total. Battery: {CurrentLevel}%.");
            }

        }
    }
}
