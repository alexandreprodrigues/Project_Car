using Classes;

namespace MainApp.Menus
{
    public static class CarMenu
    {
        public static void ShowCarMenu(List<Car> cars)
        {
            List<string> menuOptions = new() { "Create", "View", "Go back" };
            bool showCarMenu = true;

            while (showCarMenu)
            {
                Console.Clear();
                Console.WriteLine("-- Cars --\n");
                for (int i = 0; i < menuOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menuOptions[i]}");
                }

                Console.Write("Choose one: ");
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int choice) && choice >= 1 && choice <= menuOptions.Count)
                {
                    switch (choice)
                    {
                        case 1:
                            CreateCar(cars);
                            break;
                        case 2:
                            ViewCars(cars);
                            break;
                        case 3:
                            showCarMenu = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                }
            }
        }

        private static void CreateCar(List<Car> cars)
        {
            Console.Clear();
            Console.WriteLine("-- Create a Car --\n");

            Console.Write("Brand: ");
            var brand = Console.ReadLine() ?? string.Empty;

            Console.Write("Model: ");
            var model = Console.ReadLine() ?? string.Empty;

            Console.Write("Color: ");
            var color = Console.ReadLine() ?? string.Empty;

            Console.Write("Weight (kg): ");
            var weightStr = Console.ReadLine() ?? "0";
            double.TryParse(weightStr, out double weight);

            Console.Write("Engine Size: ");
            var engineSizeStr = Console.ReadLine() ?? "N/A";
            double.TryParse(engineSizeStr, out double engineSize);

            Console.Write("Horse Power (HP): ");
            var horsePowerStr = Console.ReadLine() ?? "0";
            double.TryParse(horsePowerStr, out double horsePower);

            Console.Write("Fuel Tank (y/n): ");
            var fuelTankAnswer = Console.ReadLine();
            FuelTank? fuelTankObj = null;

            if (fuelTankAnswer?.ToLower() == "y")
            {
                Console.Write("  Type: ");
                var fuelType = Console.ReadLine() ?? string.Empty;

                Console.Write("  Capacity (L): ");
                var fuelCapacityStr = Console.ReadLine() ?? "0";
                if (double.TryParse(fuelCapacityStr, out double fuelCapacity))
                {
                    fuelTankObj = new FuelTank(fuelType, fuelCapacity);
                }
            }

            Console.Write("Battery (y/n): ");
            var batteryAnswer = Console.ReadLine();
            Battery? batteryObj = null;

            if (batteryAnswer?.ToLower() == "y")
            {
                Console.Write("  Type: ");
                var batteryType = Console.ReadLine() ?? string.Empty;

                Console.Write("  Capacity (kWh): ");
                var batteryCapacityStr = Console.ReadLine() ?? "0";

                if (double.TryParse(batteryCapacityStr, out double batteryCapacity))
                {
                    batteryObj = new Battery(batteryType, batteryCapacity);
                }
            }

            cars.Add(new Car(
                brand,
                model,
                color,
                weight,
                new Engine(engineSize, horsePower),
                fuelTankObj,
                batteryObj
            ));

            Console.WriteLine("\nCar created successfully!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        private static void ViewCars(List<Car> cars)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-- List of Cars --\n");

                if (cars.Count == 0)
                {
                    Console.WriteLine("No cars have been created yet.");
                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey();
                    return;
                }

                for (int i = 0; i < cars.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {cars[i].Brand} {cars[i].Model}");
                }

                Console.WriteLine($"{cars.Count + 1}. Go back");

                Console.Write("Choose one: ");
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int choice))
                {
                    if (choice == cars.Count + 1)
                    {
                        return;
                    }

                    if (choice >= 1 && choice <= cars.Count)
                    {
                        ShowCarDetails(cars[choice - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid car number. Press any key to try again...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Press any key to try again...");
                    Console.ReadKey();
                }
            }
        }

        private static void ShowCarDetails(Car car)
        {
            Console.Clear();
            Console.WriteLine("-- Car Details --\n");
            Console.WriteLine($"Brand: {car.Brand}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Color: {car.Color}");
            Console.WriteLine($"Weight: {car.Weight} kg");
            Console.WriteLine($"Engine size: {car.Engine.EngineSize}");
            Console.WriteLine($"Horse power: {car.Engine.HorsePower} HP");

            if (car.FuelTank != null)
            {
                Console.WriteLine($"Fuel Tank: {car.FuelTank.Type} ({car.FuelTank.Capacity} L)");
            }
            else
            {
                Console.WriteLine("Fuel Tank: N/A");
            }

            // Battery
            if (car.Battery != null)
            {
                Console.WriteLine($"Battery: {car.Battery.Type} ({car.Battery.Capacity} kWh)");
            }
            else
            {
                Console.WriteLine("Battery: N/A");
            }

            Console.WriteLine("\nPress any key to return to the list...");
            Console.ReadKey();
        }
    }
}
