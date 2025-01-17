namespace ClassLibrary
{
    public class Engine
    {
        public double EngineSize { get; set; }
        public double HorsePower { get; set; }
        public bool IsRunning { get; set;}

        public Engine(double engineSize, double horsePower)
        {
            EngineSize = engineSize;
            HorsePower = horsePower;
        }

        public void TurnOn()
        {
            IsRunning = true;

            Console.WriteLine("Engine started");
        }

        public void TurnOff()
        {
            IsRunning = false;

            Console.WriteLine("Engine stopped");
        }
    }
}
