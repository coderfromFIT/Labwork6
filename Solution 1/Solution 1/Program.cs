using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

// Abstract class representing a generic vehicle
public abstract class Vehicle
{
    // Properties
    public double Speed { get; set; }
    public int Capacity { get; set; }

    // Method to move the vehicle
    public abstract void Move();
}

// Class representing a human with speed and movement method
public class Human
{
    // Properties
    public double Speed { get; set; }

    // Method for human movement
    public void Move()
    {
        Console.WriteLine("Walking...");
    }
}

// Derived class Car from Vehicle
public class Car : Vehicle
{
    // Custom properties and methods for Car
    public bool HasAirConditioning { get; set; }

    public override void Move()
    {
        Console.WriteLine("Driving a car...");
    }
}

// Derived class Bus from Vehicle
public class Bus : Vehicle
{
    // Custom properties and methods for Bus
    public int PassengerCount { get; set; }

    public override void Move()
    {
        Console.WriteLine("Taking the bus...");
    }
}

// Derived class Train from Vehicle
public class Train : Vehicle
{
    // Custom properties and methods for Train
    public string TrainType { get; set; }

    public override void Move()
    {
        Console.WriteLine("Traveling by train...");
    }
}

// Class representing a transport network
public class TransportNetwork
{
    // List of vehicles in the network
    private List<Vehicle> vehicles;

    // Constructor
    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
    }

    // Method to add a vehicle to the network
    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    // Method to control the movement of vehicles in the network
    public void ControlTraffic()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }
}

// Class representing a route with start and end points
public class Route
{
    // Properties
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }

    // Method to calculate the optimal route based on the type of transport
    public string CalculateOptimalRoute(Vehicle vehicle)
    {
        // Logic to calculate the optimal route
        return $"Optimal route from {StartPoint} to {EndPoint} for {vehicle.GetType().Name}";
    }
}

// Extension of the model to include logic for passenger boarding and alighting
public class PassengerLogic
{
    // Method to handle passenger boarding
    public void BoardPassenger(Vehicle vehicle)
    {
        Console.WriteLine($"Passenger boarding on {vehicle.GetType().Name}...");
    }

    // Method to handle passenger alighting
    public void AlightPassenger(Vehicle vehicle)
    {
        Console.WriteLine($"Passenger alighting from {vehicle.GetType().Name}...");
    }
}

// Example Usage
class Program
{
    static void Main()
    {
        // Create instances of vehicles
        Car car = new Car { Speed = 60, Capacity = 4, HasAirConditioning = true };
        Bus bus = new Bus { Speed = 40, Capacity = 30, PassengerCount = 15 };
        Train train = new Train { Speed = 80, Capacity = 200, TrainType = "Express" };

        // Create a transport network
        TransportNetwork transportNetwork = new TransportNetwork();
        transportNetwork.AddVehicle(car);
        transportNetwork.AddVehicle(bus);
        transportNetwork.AddVehicle(train);

        // Control traffic in the network
        transportNetwork.ControlTraffic();

        // Create a route
        Route route = new Route { StartPoint = "A", EndPoint = "B" };

        // Calculate optimal route for each vehicle
        Console.WriteLine(route.CalculateOptimalRoute(car));
        Console.WriteLine(route.CalculateOptimalRoute(bus));
        Console.WriteLine(route.CalculateOptimalRoute(train));

        // Example passenger boarding and alighting logic
        PassengerLogic passengerLogic = new PassengerLogic();
        passengerLogic.BoardPassenger(bus);
        passengerLogic.AlightPassenger(train);
        Console.ReadKey();
    }
}
