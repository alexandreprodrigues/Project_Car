﻿using Interfaces;

namespace Classes
{
    public class FuelTank : IEnergySource
    {
        public string Type { get; set; }
        public double Capacity { get; set; }
        public double CurrentLevel { get; set; }

        public FuelTank(string fuelType, double capacity) 
        {
            Capacity = capacity;
            Type = fuelType;
            CurrentLevel = capacity;
        }

        public void Add(double amount)
        {
            if (CurrentLevel + amount > Capacity)
            {
                Console.WriteLine("Cannot fill more than the total capacity of the tank");
            } 
            else
            {
                CurrentLevel += amount;

                Console.WriteLine($"Added {amount} litters to the tank. Tank: {CurrentLevel}");
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

                Console.WriteLine($"Removed {amount} litters to the tank. Tank: {CurrentLevel}");
            }

        }
    }
}
