namespace ClassLibrary
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public List<Factory> Factories { get; set; }

        public Manufacturer(string name, List<Factory> factories)
        {
            Name = name;
            Factories = factories;
        }
    }
}
