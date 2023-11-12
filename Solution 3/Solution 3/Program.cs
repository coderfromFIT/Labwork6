using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

public class Quaternion
{
    // Properties
    public double W { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    // Constructors
    public Quaternion(double w, double x, double y, double z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    // Overloaded operators for basic arithmetic operations
    public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W + q2.W, q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z);
    }

    public static Quaternion operator -(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W - q2.W, q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z);
    }

    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        double w = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;
        double x = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
        double y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X;
        double z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W;

        return new Quaternion(w, x, y, z);
    }

    // Method to calculate the norm of a quaternion
    public double Norm()
    {
        return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
    }

    // Method to calculate the conjugate of a quaternion
    public Quaternion Conjugate()
    {
        return new Quaternion(W, -X, -Y, -Z);
    }

    // Method to calculate the inverse of a quaternion
    public Quaternion Inverse()
    {
        double normSquared = W * W + X * X + Y * Y + Z * Z;
        double factor = 1.0 / normSquared;

        return new Quaternion(W * factor, -X * factor, -Y * factor, -Z * factor);
    }

    // Overloaded comparison operators
    public static bool operator ==(Quaternion q1, Quaternion q2)
    {
        return q1.Equals(q2);
    }

    public static bool operator !=(Quaternion q1, Quaternion q2)
    {
        return !(q1 == q2);
    }

    // Override Equals method
    public override bool Equals(object obj)
    {
        if (!(obj is Quaternion))
            return false;

        Quaternion other = (Quaternion)obj;
        return W == other.W && X == other.X && Y == other.Y && Z == other.Z;
    }

    // Override GetHashCode method
    public override int GetHashCode()
    {
        return HashCode.Combine(W, X, Y, Z);
    }

    // Method to convert a quaternion to a rotation matrix
    public double[,] ToRotationMatrix()
    {
        double[,] matrix = new double[3, 3];

        matrix[0, 0] = 1 - 2 * (Y * Y + Z * Z);
        matrix[0, 1] = 2 * (X * Y - W * Z);
        matrix[0, 2] = 2 * (X * Z + W * Y);

        matrix[1, 0] = 2 * (X * Y + W * Z);
        matrix[1, 1] = 1 - 2 * (X * X + Z * Z);
        matrix[1, 2] = 2 * (Y * Z - W * X);

        matrix[2, 0] = 2 * (X * Z - W * Y);
        matrix[2, 1] = 2 * (Y * Z + W * X);
        matrix[2, 2] = 1 - 2 * (X * X + Y * Y);

        return matrix;
    }

    // Static method to create a quaternion from an axis and an angle (rotation)
    public static Quaternion FromAxisAngle(double angle, double axisX, double axisY, double axisZ)
    {
        double halfAngle = angle / 2.0;
        double sinHalfAngle = Math.Sin(halfAngle);

        return new Quaternion(Math.Cos(halfAngle), axisX * sinHalfAngle, axisY * sinHalfAngle, axisZ * sinHalfAngle);
    }

    // Static method to convert a rotation matrix to a quaternion
    public static Quaternion FromRotationMatrix(double[,] matrix)
    {
        double trace = matrix[0, 0] + matrix[1, 1] + matrix[2, 2];

        double w, x, y, z;

        if (trace > 0)
        {
            double s = 0.5 / Math.Sqrt(trace + 1.0);
            w = 0.25 / s;
            x = (matrix[2, 1] - matrix[1, 2]) * s;
            y = (matrix[0, 2] - matrix[2, 0]) * s;
            z = (matrix[1, 0] - matrix[0, 1]) * s;
        }
        else if (matrix[0, 0] > matrix[1, 1] && matrix[0, 0] > matrix[2, 2])
        {
            double s = 2.0 * Math.Sqrt(1.0 + matrix[0, 0] - matrix[1, 1] - matrix[2, 2]);
            w = (matrix[2, 1] - matrix[1, 2]) / s;
            x = 0.25 * s;
            y = (matrix[0, 1] + matrix[1, 0]) / s;
            z = (matrix[0, 2] + matrix[2, 0]) / s;
        }
        else if (matrix[1, 1] > matrix[2, 2])
        {
            double s = 2.0 * Math.Sqrt(1.0 + matrix[1, 1] - matrix[0, 0] - matrix[2, 2]);
            w = (matrix[0, 2] - matrix[2, 0]) / s;
            x = (matrix[0, 1] + matrix[1, 0]) / s;
            y = 0.25 * s;
            z = (matrix[1, 2] + matrix[2, 1]) / s;
        }
        else
        {
            double s = 2.0 * Math.Sqrt(1.0 + matrix[2, 2] - matrix[0, 0] - matrix[1, 1]);
            w = (matrix[1, 0] - matrix[0, 1]) / s;
            x = (matrix[0, 2] + matrix[2, 0]) / s;
            y = (matrix[1, 2] + matrix[2, 1]) / s;
            z = 0.25 * s;
        }

        return new Quaternion(w, x, y, z);
    }
}

// Example Usage
class Program
{
    static void Main()
    {
        // Create two quaternions
        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Quaternion q2 = new Quaternion(5, 6, 7, 8);

        // Perform arithmetic operations
        Quaternion additionResult = q1 + q2;
        Quaternion subtractionResult = q1 - q2;
        Quaternion multiplicationResult = q1 * q2;

        // Display results
        Console.WriteLine("Addition: " + additionResult.W + ", " + additionResult.X + ", " + additionResult.Y + ", " + additionResult.Z);
        Console.WriteLine("Subtraction: " + subtractionResult.W + ", " + subtractionResult.X + ", " + subtractionResult.Y + ", " + subtractionResult.Z);
        Console.WriteLine("Multiplication: " + multiplicationResult.W + ", " + multiplicationResult.X + ", " + multiplicationResult.Y + ", " + multiplicationResult.Z);

        // Calculate norm, conjugate, and inverse
        double norm = q1.Norm();
        Quaternion conjugate = q1.Conjugate();
        Quaternion inverse = q1.Inverse();

        Console.WriteLine("Norm: " + norm);
        Console.WriteLine("Conjugate: " + conjugate.W + ", " + conjugate.X + ", " + conjugate.Y + ", " + conjugate.Z);
        Console.WriteLine("Inverse: " + inverse.W + ", " + inverse.X + ", " + inverse.Y + ", " + inverse.Z);

        // Compare quaternions
        bool areEqual = q1 == q2;
        bool areNotEqual = q1 != q2;

        Console.WriteLine("Equality: " + areEqual);
        Console.WriteLine("Inequality: " + areNotEqual);

        // Convert quaternion to rotation matrix
        double[,] rotationMatrix = q1.ToRotationMatrix();

        Console.WriteLine("Rotation Matrix:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(rotationMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Convert rotation matrix back to quaternion
        Quaternion fromRotationMatrix = Quaternion.FromRotationMatrix(rotationMatrix);

        Console.WriteLine("Quaternion from Rotation Matrix: " + fromRotationMatrix.W + ", " + fromRotationMatrix.X + ", " + fromRotationMatrix.Y + ", " + fromRotationMatrix.Z);
    
        Console.ReadKey();
    }
}
