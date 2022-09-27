using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingAreasLibrary
{
    /// <summary>
    ///  Абстрактный класс "Фигура" - от него наследуются классы с конкретными фигурами
    /// </summary>
    public abstract class Figure
    {
        // Абстрактный метод "Вычислить площадь" - в реализациях 
        // абстрактного класса "Фигура" он будет переопределяться с функционалом,
        // необходимым для вычисления площади заданного типа фигуры 
        public abstract double GetArea();
    }
}
