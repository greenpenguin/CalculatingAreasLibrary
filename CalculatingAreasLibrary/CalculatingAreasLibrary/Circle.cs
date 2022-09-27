using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingAreasLibrary
{
    /// <summary>
    /// Класс "Круг" - реализация абстрактного класса "Фигура"
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Свойство для хранения длины радиуса круга
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Конструктор класса "Круг"
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        /// <exception cref="ArgumentOutOfRangeException">Если пользователь пытается задать отрицательное значение радиуса, выдается исключение</exception>
        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException("Радиус круга не может быть отрицательным значением!");
            }
            Radius = radius;
        }

        /// <summary>
        /// Переопределенный метод для вычисления площади круга
        /// </summary>
        public override double GetArea()
        {
            // Вычисление площади круга как произведения числа пи на квадрат длины радиуса
            return Math.PI * Radius * Radius;
        }
    }
}
