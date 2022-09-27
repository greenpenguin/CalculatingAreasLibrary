using CalculatingAreasLibrary;

namespace CalculatingAreasLibraryTests
{
    public class CircleTests
    {
        /// <summary>
        /// ����, ������������, ��� �������� ����� � ������������� �������� ��������
        /// </summary>
        [Test]
        public void CreateCircleWithPositiveRadius()
        {
            Assert.DoesNotThrow(() => new Circle(1));
        }

        /// <summary>
        /// ����, ������������, ��� ��� �������� ����� � ������� �������� �� �������� ����������
        /// </summary>
        [Test]
        public void CreateCircleWithZeroRadius()
        {
            Assert.DoesNotThrow(() => new Circle(0));
        }

        /// <summary>
        /// ����, ������������, ��� ��� �������� ����� � ������������� �������� �������� ����������
        /// </summary>
        [Test]
        public void NotCreateCircleWithNegativeRadius()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
        }

        /// <summary>
        /// ����, ������������, ��� ����� ���������� ������� ��������� ������� �������
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
        /// ����, ������������, ��� ����� ���������� ������� �� ������� ������� �����������
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