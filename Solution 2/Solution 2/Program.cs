using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

// Class for performing mathematical operations
public class MathOperations
{
    // Overloaded method for adding two numbers
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Overloaded method for adding an array of numbers
    public int Add(params int[] numbers)
    {
        int sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    // Overloaded method for adding two matrices
    public int[,] Add(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int columns = matrix1.GetLength(1);

        int[,] result = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    // Additional methods for subtraction, multiplication, etc.
    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int[,] Multiply(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int columns = matrix1.GetLength(1);

        int[,] result = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = matrix1[i, j] * matrix2[i, j];
            }
        }

        return result;
    }

    // Add more methods for other operations as needed
}

// Example Usage
class Program
{
    static void Main()
    {
        // Create an instance of MathOperations
        MathOperations mathOps = new MathOperations();

        // Test different overloaded Add methods
        Console.WriteLine("Add two numbers: " + mathOps.Add(5, 3));

        Console.WriteLine("Add an array of numbers: " + mathOps.Add(1, 2, 3, 4, 5));

        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };

        int[,] resultMatrix = mathOps.Add(matrix1, matrix2);

        Console.WriteLine("Add two matrices:");
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                Console.Write(resultMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Test other operations
        Console.WriteLine("Subtract: " + mathOps.Subtract(8, 3));

        int[,] multiplyResult = mathOps.Multiply(matrix1, matrix2);

        Console.WriteLine("Multiply two matrices:");
        for (int i = 0; i < multiplyResult.GetLength(0); i++)
        {
            for (int j = 0; j < multiplyResult.GetLength(1); j++)
            {
                Console.Write(multiplyResult[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}
