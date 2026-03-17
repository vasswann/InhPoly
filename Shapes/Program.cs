namespace Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Circle circle = new Circle(5);
            Rectangle rectangle = new Rectangle(4, 6);
            Triangle triangle = new Triangle(3, 8);

            Console.WriteLine("Circle Area: " + circle.CalculateArea());
            Console.WriteLine("Rectangle Area: " + rectangle.CalculateArea());
            Console.WriteLine("Triangle Area: " + triangle.CalculateArea());
        }
    }
}
