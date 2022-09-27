using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingAreasLibrary
{
    /// <summary>
    /// Класс "Треугольник" - реализация абстрактного класса "Фигура"
    /// </summary>
    public class Triangle : Figure
    {
        /// <summary>
        /// Свойство для хранения длины стороны А
        /// </summary>
        public double SideA { get; }

        /// <summary>
        /// Свойство для хранения длины стороны B
        /// </summary>
        public double SideB { get; }

        /// <summary>
        /// Свойство для хранения длины стороны C
        /// </summary>
        public double SideC { get; }

        /// <summary>
        /// Конструктор класса "Треугольник"
        /// </summary>
        /// <param name="sideA">Сторона A</param>
        /// <param name="sideB">Сторона B</param>
        /// <param name="sideC">Сторона C</param>
        /// <exception cref="ArgumentOutOfRangeException">Если пользователь пытается задать отрицательное значение стороны, выдается исключение</exception>
        /// <exception cref="ArgumentException">Если пользователь пытается задать длины сторон, одна из которых больше либо равна сумме двух других, треугольник не существует - , выдается исключение</exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA < 0 || sideB < 0 || sideC < 0)
            {
                throw new ArgumentOutOfRangeException("Сторона треугольника не может быть отрицательным значением!");
            }

            // Треугольник существует только тогда, когда сумма двух его сторон больше третьей.
            // Проверка этого условия
            if (sideA >= sideB + sideC ||
                sideB >= sideA + sideC ||
                sideC >= sideB + sideA)
            {
                throw new ArgumentException("Треугольник с такими сторонами не существует - одна из сторон треугольника больше либо равна суммы двух других!");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// Переопределенный метод для вычисления площади треугольника
        /// </summary>
        public override double GetArea()
        {
            // Вычисление площади треугольника через полупериметр
            double halfPerimeter = (SideA + SideB + SideC) / 2;

            return Math.Sqrt(halfPerimeter *
                            (halfPerimeter - SideA) *
                            (halfPerimeter - SideB) *
                            (halfPerimeter - SideC));
        }

        /// <summary>
        /// Метод для определения является ли треугольник прямогульным
        /// </summary>
        public bool IsTriangleRightAngled()
        {
            // Треугольник является прямоугольным, если квадрат гиппотенузы равен сумме квадратов катетов.
            // Предположим, что треугольник прямоугольный. В этом случае гиппотенузой будет наибольшая сторона.
            // Найдем наибольшую сторону - добавим все стороны в лист и отсортируем его. 
            // Наибольшая сторона будет последним элементом листа
            List<double> sidesInAscendingOrderList = new List<double>() { SideA, SideB, SideC};
            sidesInAscendingOrderList.Sort();

            // Проверим, что наибольшая сторона равна квадратному корню из суммы квадратов катетов.
            // Если это так, треугольник прямоугольный
            if (sidesInAscendingOrderList[2] == Math.Sqrt(sidesInAscendingOrderList[0] * sidesInAscendingOrderList[0] + 
                                                sidesInAscendingOrderList[1] * sidesInAscendingOrderList[1]))
            {
                return true;
            }

            return false;
        }
    }
}
