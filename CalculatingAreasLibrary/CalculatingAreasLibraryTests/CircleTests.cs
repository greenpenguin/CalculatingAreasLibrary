using CalculatingAreasLibrary;

namespace CalculatingAreasLibraryTests
{
    public class CircleTests
    {
        /// <summary>
        /// Тест, определяющий, что создание круга с положительным радиусом возможно
        /// </summary>
        [Test]
        public void CreateCircleWithPositiveRadius()
        {
            Assert.DoesNotThrow(() => new Circle(1));
        }

        /// <summary>
        /// Тест, определяющий, что при создании круга с нулевым радиусом не выдается исключение
        /// </summary>
        [Test]
        public void CreateCircleWithZeroRadius()
        {
            Assert.DoesNotThrow(() => new Circle(0));
        }

        /// <summary>
        /// Тест, определяющий, что при создании круга с отрицательным радиусом выдается исключение
        /// </summary>
        [Test]
        public void NotCreateCircleWithNegativeRadius()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
        }

        /// <summary>
        /// Тест, определяющий, что метод вычисления площади правильно считает площадь
        /// </summary>
        [Test]
        public void GetCorrectCircleArea()
        {
            double radius = 5;
            double expected = 78.53981633974483;

            Circle circle = new Circle(radius);

            Assert.That(circle.GetArea(), Is.EqualTo(expected));
        }

        /// <summary>
        /// Тест, определяющий, что метод вычисления площади не считает площадь неправильно
        /// </summary>
        [Test]
        public void NotGetIncorrectCircleArea()
        {
            double radius = 3;
            double expected = 1;

            Circle circle = new Circle(radius);

            Assert.That(expected, Is.Not.EqualTo(circle.GetArea()));
        }

    }
}