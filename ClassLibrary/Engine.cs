namespace Classes
{
    public class Engine
    {
        public string? EngineSize { get; set; }
        public string HorsePower { get; set; }
        public bool IsRunning { get; set; }

        public Engine(string? engineSize, string horsePower)
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
