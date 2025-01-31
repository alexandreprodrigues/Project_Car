using Classes;

namespace Menus
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

            string brand = ReadInput("Brand: ");
            string model = ReadInput("Model: ");
            string color = ReadInput("Color: ");
            string weight = ReadInput("Weight (kg): ");
            string engineSize = ReadInput("Engine Size: ");
            string horsePower = ReadInput("Horse Power (HP): ");

            FuelTank? fuelTankObj = null;
            if (ReadInput("Fuel Tank (y/n): ", "n").ToLower() == "y")
            {
                string fuelType = ReadInput("  Type: ");
                double? fuelCapacity = ReadDoubleInput("  Capacity (L): ");
                if (fuelCapacity.HasValue)
                {
                    fuelTankObj = new FuelTank(fuelType, fuelCapacity.Value);
                }
            }

            Battery? batteryObj = null;
            if (ReadInput("Battery (y/n): ", "n").ToLower() == "y")
            {
                string batteryType = ReadInput("  Type: ");
                double? batteryCapacity = ReadDoubleInput("  Capacity (kWh): ");
                if (batteryCapacity.HasValue)
                {
                    batteryObj = new Battery(batteryType, batteryCapacity.Value);
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

            string ReadInput(string consoleMessage, string defaultValue = "N/A")
            {
                Console.Write(consoleMessage);
                var userInput = Console.ReadLine();
                return !string.IsNullOrEmpty(userInput) ? userInput : defaultValue;
            }

            double? ReadDoubleInput(string consoleMessage)
            {
                Console.Write(consoleMessage);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                return null;
            }
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
                    Console.WriteLine($"{i + 1}. {cars[i].Brand} {(cars[i].Model != "N/A" ? cars[i].Model : "")}");
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

            ShowComponent("Fuel Tank", car.FuelTank, car.FuelTank?.Type ?? "N/A", car.FuelTank?.Capacity ?? 0, "L");
            ShowComponent("Battery", car.Battery, car.Battery?.Type ?? "N/A", car.Battery?.Capacity ?? 0, "kWh");

            void ShowComponent(string name, object? component, string type, double capacity, string unit)
            {
                if (component != null)
                {
                    Console.WriteLine(!string.IsNullOrEmpty(type) && type != "N/A"
                        ? $"{name}: {type} ({capacity} {unit})"
                        : $"{name}: {capacity} {unit}");
                }
                else
                {
                    Console.WriteLine($"{name}: N/A");
                }
            }

            Console.WriteLine("\nPress any key to return to the list...");
            Console.ReadKey();
        }
    }
}
