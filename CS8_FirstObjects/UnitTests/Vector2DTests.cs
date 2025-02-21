using CS8_FirstObjects.Models;

namespace CS8_FirstObjects.UnitTests;

public static class Vector2DTests
{
    private static readonly Random _random = new(12345);

    public static List<Vector2D> GenerateRandomVectors(int repeats = 10)
    {
        List<Vector2D> tests = new();
        for (int i = 0; i < repeats; i++)
        {
            bool polar = _random.Next(2) == 0;
            if (polar)
            {
                try
                {
                    var angle = AngleTests.GenerateRandomAngleMeasures(1)[0];
                    tests.Add(Vector2D.FromPolar(20 * _random.NextDouble() - 10.0, angle));
                    continue;
                }
                catch
                {
                    // Ignore the NotImplemented Exception.
                }
            }

            tests.Add(Vector2D.FromRectangular(20 * _random.NextDouble() - 10.0, 20 * _random.NextDouble() - 10.0));
        }

        return tests;
    }

    public static void TestPrinting(List<Vector2D> vectors)
    {
        List<string> formats =
        [
            "<x, y>",
            "<{x:0.00}, {y:0.00}>",
            /* TODO: Add more formats as you complete parts of the Vector2D class */
        ];

        foreach (var vector in vectors)
        {
            Console.WriteLine($"Default: {vector}");
            foreach (var format in formats)
                Console.WriteLine($"{format} => {vector.ToString(format)}");
            Console.WriteLine("_________________________________________");
        }
    }

    public static void TestUnitVectors(List<Vector2D> vectors)
    {
        foreach (var v in vectors)
        {
            var fromPolar = v.UnitVector(computeAsRectangular: false);
            var fromRectangular = v.UnitVector();

            Console.WriteLine($"v => {v}, magnitude: {v.Magnitude}, angle: {v.Angle}");
            Console.WriteLine($"fromPolar => {fromPolar}, magnitude: {fromPolar.Magnitude}, angle: {fromPolar.Angle}");
            Console.WriteLine(
                $"fromRectangular => {fromRectangular}, magnitude: {fromRectangular.Magnitude}, angle: {fromRectangular.Angle}");
            Console.WriteLine("__________________________________");
        }
    }

    public static void TestAdditionOperator(List<Vector2D> vectors)
    {
        for (int i = 0; i < 10; i += 2)
        {
            var vector1 = vectors[i];
            var vector2 = vectors[i + 1];
            Console.WriteLine($"vector1: {vector1}, vector2: {vector2}");
            Console.WriteLine($"Sum = {vector1 + vector2}");
        }
    }

    public static void TestSubtractionOperator(List<Vector2D> vectors)
    {
        for (int i = 0; i < 10; i += 2)
        {
            var vector1 = vectors[i];
            var vector2 = vectors[i + 1];
            Console.WriteLine($"vector1: {vector1}, vector2: {vector2}");
            Console.WriteLine($"Sum = {vector1 - vector2}");
        }

    }

    public static void TestProjectOnto(List<Vector2D> others)
    {
        foreach(var vector in others)
        {
            this.ProjectOnto(vector);
        }
           
    }
}