using System;

namespace GeometryLibrary
{
    // Интерфейс для всех фигур
    public interface IShape
    {
        // Метод для вычисления площади
        double GetArea();
    }

    // Класс для круга, реализующий интерфейс IShape
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        // Реализация метода для вычисления площади круга
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    // Класс для треугольника, реализующий интерфейс IShape
    public class Triangle : IShape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        // Реализация метода для вычисления площади треугольника по формуле Герона
        public double GetArea()
        {
            double s = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        // Метод для проверки, является ли треугольник прямоугольным
        public bool IsRightAngled()
        {
            double[] sides = { SideA, SideB, SideC };
            Array.Sort(sides);
            return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1e-10;
        }
    }

    // Пример кода для прямоугольника
    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            return Width * Height;
        }
    }


    // Фабрика для работы с фигурами
    public static class ShapeFactory
    {
        // Метод для вычисления площади фигуры без знания типа фигуры в compile-time
        public static double GetArea(IShape shape)
        {
            return shape.GetArea();
        }
    }
}
