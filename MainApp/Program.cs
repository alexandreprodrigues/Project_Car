using Classes;

List<Manufacturer> manufacturers = new();
List<Driver> drivers = new();
List<Car> cars = new();

List<string> menu1 = new() { "Manufacturers", "Drivers", "Cars" };

//TODO: Create separate .cs files to create MANUFACTURERS, DRIVERS and CARS, otherwise main file to confusing!

bool showMenu = true;
while (showMenu)
{
    for (int i = 0; i < menu1.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {menu1[i]}");
    }

    Console.Write("Choose one: ");
    var userInput1 = Console.ReadLine();

    if (int.TryParse(userInput1, out int choice1) && choice1 >= 1 && choice1 <= menu1.Count)
    {
        List<string> menu2 = new() { "Create", "View", "Go back" };

        bool showCarMenu = true;
        while (showCarMenu)
        {
            Console.Clear();
            Console.WriteLine($"-- {menu1[choice1 - 1]} --\n");

            for (int i = 0; i < menu2.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu2[i]}");
            }

            Console.Write("Choose one: ");
            var userInput2 = Console.ReadLine();

            if (int.TryParse(userInput2, out int choice2) && choice2 >= 1 && choice2 <= menu2.Count)
            {
                switch (choice2)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("-- Create a Car --\n");

                        Console.Write("Brand: ");
                        var brand = Console.ReadLine();

                        Console.Write("Model: ");
                        var model = Console.ReadLine();

                        Console.Write("Color: ");
                        var color = Console.ReadLine();

                        Console.Write("Weight: ");
                        var weight = Console.ReadLine();

                        Console.Write("Engine Size: ");
                        var engineSize = Console.ReadLine();

                        Console.Write("Horse Power: ");
                        var horsePower = Console.ReadLine();

                        Console.Write("Fuel Tank (y/n): ");
                        var fuelTankAnswer = Console.ReadLine();
                        FuelTank? fuelTankObj = null;
                        if (fuelTankAnswer?.ToLower() == "y")
                        {
                            Console.Write("  Type: ");
                            var fuelType = Console.ReadLine();

                            Console.Write("  Capacity: ");
                            var fuelCapacity = Console.ReadLine();

                            fuelTankObj = new FuelTank(fuelType, double.Parse(fuelCapacity));
                        }

                        Console.Write("Battery (y/n): ");
                        var batteryAnswer = Console.ReadLine();
                        Battery? batteryObj = null;
                        if (batteryAnswer?.ToLower() == "y")
                        {
                            Console.Write("  Type: ");
                            var batteryType = Console.ReadLine();

                            Console.Write("  Capacity: ");
                            var batteryCapacity = Console.ReadLine();

                            batteryObj = new Battery(batteryType, double.Parse(batteryCapacity));
                        }

                        cars.Add(
                            new Car(
                                brand,
                                model,
                                color,
                                double.Parse(weight),
                                new Engine(double.Parse(engineSize), double.Parse(horsePower)),
                                fuelTankObj,
                                batteryObj
                            )
                        );

                        Console.WriteLine("\nCar created successfully!");

                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("-- List of cars --\n");

                        if (cars.Count == 0)
                        {
                            Console.WriteLine("No cars have been created yet.");
                        }
                        else
                        {
                            foreach (var (car, index) in cars.Select((car, index) => (car, index)))
                            {
                                Console.WriteLine($"{index + 1}. {car.Brand}");
                            }
                        }

                        Console.WriteLine("\nPress any key to return...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        showCarMenu = false;
                        Console.Clear();
                        showMenu = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Press any key to try again...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Invalid option.");
    }
}


