using System;
using Xunit;

namespace QuadraticEquationSolver
{

    public class QuadraticEquation
    {
        public static (bool hasRoots, double root1, double root2) Solve(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                return (false, 0, 0);
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                return (true, root, root); 
            }
            else
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return (true, root1, root2);
            }
        }
    }

    public class QuadraticEquationTests
    {
        [Theory]
        [InlineData(1, -3, 2, true, 2, 1)] 
        [InlineData(1, 2, 1, true, -1, -1)] 
        [InlineData(1, 0, 1, false, 0, 0)]
        public void Solve_ShouldReturnCorrectRoots(double a, double b, double c, bool hasRoots, double root1, double root2)
        {
            var result = QuadraticEquation.Solve(a, b, c);

            Assert.Equal(hasRoots, result.hasRoots);
            if (hasRoots)
            {
                Assert.Equal(root1, result.root1);
                Assert.Equal(root2, result.root2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter coefficients for the quadratic equation (ax² + bx + c = 0):");
            Console.Write("a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c: ");
            double c = double.Parse(Console.ReadLine());

            var result = QuadraticEquation.Solve(a, b, c);

            if (result.hasRoots)
            {
                if (result.root1 == result.root2)
                {
                    Console.WriteLine($"The equation has one real root: {result.root1}");
                }
                else
                {
                    Console.WriteLine($"The equation has two real roots: {result.root1} and {result.root2}");
                }
            }
            else
            {
                Console.WriteLine("The equation has no real roots.");
            }
        }
    }
}