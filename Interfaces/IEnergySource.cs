namespace Interfaces
{
    public interface IEnergySource
    {
        public string Type { get; set; }
        public double Capacity { get; set; }
        public double CurrentLevel { get; set; }

        public void Add(double amount);

        public void Remove(double amount);
    }
}
