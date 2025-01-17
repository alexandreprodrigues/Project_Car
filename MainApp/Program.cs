using ClassLibrary;

//var manufacturerFord = new Manufacturer("Ford", [new Factory("Paris"), new Factory("New York")]);

//Console.WriteLine($"Manufacturer: {manufacturerFord.Name}");
//Console.WriteLine($"Factories:");
//foreach (var factory in manufacturerFord.Factories)
//{
//    Console.WriteLine($" - {factory.Location}");
//}

var myCar = new Car("Ford", "Fiesta", "white", new Engine(999, 100), new FuelTank("petrol", 42));

Console.WriteLine(myCar.Engine.IsRunning);

myCar.StartEngine();

Console.WriteLine(myCar.Engine.IsRunning);

Console.WriteLine($"{myCar.Brand} {myCar.Model} | {myCar.Color} | {myCar.Engine.HorsePower}HP");