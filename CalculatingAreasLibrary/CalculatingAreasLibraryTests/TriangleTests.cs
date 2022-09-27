using CalculatingAreasLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingAreasLibraryTests
{
    public class TriangleTests
    {
        /// <summary>
        /// Тест, определяющий, что создание треугольника с положительными сторонами не вызывает исключение
        /// </summary>
        [Test]
        public void CreateTriangleWithPositiveSides()
        {
            Assert.DoesNotThrow(() => new Triangle(2, 2, 3));
        }

        /// <summary>
        /// Тест, определяющий, что при создании треугольника с отлицательной стороной выдается исключение
        /// </summary>
        [Test]
        public void NotCreateTriangleWithNegativeSide()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, 2, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(2, -2, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(2, 2, -3));
        }

        /// <summary>
        /// Тест, определяющий, что при создании несуществующего треугольника (одна из сторон больше или равна сумме двух других) стороной выдается исключение
        /// </summary>
        [Test]
        public void NotCreateIncorrectTriangle()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 3));
            Assert.Throws<ArgumentException>(() => new Triangle(2, 1, 3));
            Assert.Throws<ArgumentException>(() => new Triangle(2, 3, 1));
        }

        /// <summary>
        /// Тест, определяющий, что заданный прямоугольный треугольник корректно определяется программой как прямоугольный
        /// </summary>
        [Test]
        public void CorrectRightTriangleCheck()
        {
            Triangle triangle = new Triangle(3, 4, 5);

            Assert.That(triangle.IsTriangleRightAngled, Is.EqualTo(true));
        }

        /// <summary>
        /// Тест, определяющий, что заданный не прямоугольный треугольник корректно не определяется программой как прямоугольный
        /// </summary>
        [Test]
        public void CorrectNotRightTriangleCheck()
        {
            Triangle triangle = new Triangle(4, 4, 5);

            Assert.That(triangle.IsTriangleRightAngled, Is.EqualTo(false));
        }

        /// <summary>
        /// Тест, определяющий, что метод вычисления площади правильно считает площадь
        /// </summary>
        [Test]
        public void GetCorrectTriangleArea()
        {
            double sideA = 3;
            double sideB = 3;
            double sideC = 4;
            double expected = 4.47213595499958;

            Triangle triangle = new Triangle(sideA, sideB, sideC);

            Assert.That(triangle.GetArea(), Is.EqualTo(expected));
        }

        /// <summary>
        /// Тест, определяющий, что метод вычисления площади не считает площадь неправильно
        /// </summary>
        [Test]
        public void NotGetIncorrectTriangleArea()
        {
            double sideA = 3;
            double sideB = 3;
            double sideC = 4;
            double expected = 1;

            Triangle triangle = new Triangle(sideA, sideB, sideC);

            Assert.That(expected, Is.Not.EqualTo(triangle.GetArea()));
        }
    }
}
