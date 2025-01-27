using Classes;
using MainApp.Menus;

namespace MainApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Manufacturer> manufacturers = new();
            List<Driver> drivers = new();
            List<Car> cars = new();

            List<string> menu = new() { "Manufacturers", "Drivers", "Cars" };

            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine("-- Welcome --\n");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i]}");
                }

                Console.Write("Choose one: ");
                var userInput1 = Console.ReadLine();

                if (int.TryParse(userInput1, out int choice) && choice >= 1 && choice <= menu.Count)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("dafsddssfs");
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("asdasdaadas");
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            CarMenu.ShowCarMenu(cars);
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}