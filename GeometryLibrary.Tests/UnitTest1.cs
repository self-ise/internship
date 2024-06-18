using System;
using Xunit;
using GeometryLibrary;

namespace GeometryLibrary.Tests
{
    // Тесты для проверки работы классов фигур
    public class ShapeTests
    {
        // Тест для проверки вычисления площади круга
        [Fact]
        public void CircleAreaTest()
        {
            var circle = new Circle(5);
            Assert.Equal(Math.PI * 25, circle.GetArea(), 5);
        }

        // Тест для проверки вычисления площади треугольника
        [Fact]
        public void TriangleAreaTest()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.Equal(6, triangle.GetArea(), 5);
        }

        // Тест для проверки, является ли треугольник прямоугольным
        [Fact]
        public void RightAngledTriangleTest()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.True(triangle.IsRightAngled());
        }

        // Тест для проверки работы фабрики фигур
        [Fact]
        public void ShapeFactoryAreaTest()
        {
            IShape circle = new Circle(5);
            IShape triangle = new Triangle(3, 4, 5);

            Assert.Equal(Math.PI * 25, ShapeFactory.GetArea(circle), 5);
            Assert.Equal(6, ShapeFactory.GetArea(triangle), 5);
        }
    }
}
