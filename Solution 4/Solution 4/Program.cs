using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

// Abstract class representing a graphic primitive
public abstract class GraphicPrimitive
{
    // Properties
    public int X { get; set; }
    public int Y { get; set; }

    // Abstract method to draw the primitive
    public abstract void Draw();

    // Method to move the primitive
    public void Move(int x, int y)
    {
        X += x;
        Y += y;
        Console.WriteLine($"Moved to new coordinates: ({X}, {Y})");
    }

    // Abstract method to scale the primitive
    public abstract void Scale(float factor);
}

// Class representing a Circle
public class Circle : GraphicPrimitive
{
    // Property
    public float Radius { get; set; }

    // Constructor
    public Circle(int x, int y, float radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    // Implementation of the Draw method for Circle
    public override void Draw()
    {
        Console.WriteLine($"Drawing Circle at coordinates ({X}, {Y}) with radius {Radius}");
    }

    // Implementation of the Scale method for Circle
    public override void Scale(float factor)
    {
        Radius *= factor;
        Console.WriteLine($"Circle scaled. New radius: {Radius}");
    }
}

// Class representing a Rectangle
public class Rectangle : GraphicPrimitive
{
    // Properties
    public float Width { get; set; }
    public float Height { get; set; }

    // Constructor
    public Rectangle(int x, int y, float width, float height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    // Implementation of the Draw method for Rectangle
    public override void Draw()
    {
        Console.WriteLine($"Drawing Rectangle at coordinates ({X}, {Y}) with width {Width} and height {Height}");
    }

    // Implementation of the Scale method for Rectangle
    public override void Scale(float factor)
    {
        Width *= factor;
        Height *= factor;
        Console.WriteLine($"Rectangle scaled. New width: {Width}, new height: {Height}");
    }
}

// Class representing a Triangle
public class Triangle : GraphicPrimitive
{
    // Properties
    public float SideLength { get; set; }

    // Constructor
    public Triangle(int x, int y, float sideLength)
    {
        X = x;
        Y = y;
        SideLength = sideLength;
    }

    // Implementation of the Draw method for Triangle
    public override void Draw()
    {
        Console.WriteLine($"Drawing Triangle at coordinates ({X}, {Y}) with side length {SideLength}");
    }

    // Implementation of the Scale method for Triangle
    public override void Scale(float factor)
    {
        SideLength *= factor;
        Console.WriteLine($"Triangle scaled. New side length: {SideLength}");
    }
}

// Class representing a Group of graphic primitives
public class Group : GraphicPrimitive
{
    // List to store the primitives in the group
    private List<GraphicPrimitive> primitives;

    // Constructor
    public Group(int x, int y)
    {
        X = x;
        Y = y;
        primitives = new List<GraphicPrimitive>();
    }

    // Method to add a primitive to the group
    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    // Implementation of the Draw method for Group
    public override void Draw()
    {
        Console.WriteLine($"Drawing Group at coordinates ({X}, {Y})");

        // Draw all primitives in the group
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    // Implementation of the Scale method for Group
    public override void Scale(float factor)
    {
        Console.WriteLine($"Scaling Group at coordinates ({X}, {Y})");

        // Scale all primitives in the group
        foreach (var primitive in primitives)
        {
            primitive.Scale(factor);
        }
    }
}

// Class representing a Graphics Editor
public class GraphicsEditor
{
    // List to store graphic primitives
    private List<GraphicPrimitive> graphicPrimitives;

    // Constructor
    public GraphicsEditor()
    {
        graphicPrimitives = new List<GraphicPrimitive>();
    }

    // Method to add a graphic primitive to the editor
    public void AddGraphicPrimitive(GraphicPrimitive primitive)
    {
        graphicPrimitives.Add(primitive);
    }

    // Method to draw all graphic primitives in the editor
    public void DrawAll()
    {
        foreach (var primitive in graphicPrimitives)
        {
            primitive.Draw();
        }
    }

    // Method to scale all graphic primitives in the editor
    public void ScaleAll(float factor)
    {
        foreach (var primitive in graphicPrimitives)
        {
            primitive.Scale(factor);
        }
    }
}

// Example Usage
class Program
{
    static void Main()
    {
        // Create instances of graphic primitives
        Circle circle = new Circle(10, 20, 5);
        Rectangle rectangle = new Rectangle(30, 40, 8, 12);
        Triangle triangle = new Triangle(50, 60, 10);

        // Create a group and add graphic primitives to it
        Group group = new Group(0, 0);
        group.AddPrimitive(circle);
        group.AddPrimitive(rectangle);
        group.AddPrimitive(triangle);

        // Create a graphics editor
        GraphicsEditor editor = new GraphicsEditor();

        // Add graphic primitives and the group to the editor
        editor.AddGraphicPrimitive(circle);
        editor.AddGraphicPrimitive(rectangle);
        editor.AddGraphicPrimitive(triangle);
        editor.AddGraphicPrimitive(group);

        // Draw all graphic primitives in the editor
        Console.WriteLine("Drawing all graphic primitives:");
        editor.DrawAll();

        // Scale all graphic primitives in the editor
        Console.WriteLine("\nScaling all graphic primitives:");
        editor.ScaleAll(2.0f);

        // Draw all graphic primitives in the editor after scaling
        Console.WriteLine("\nDrawing all graphic primitives after scaling:");
        editor.DrawAll();
        Console.ReadKey();
    }
}
