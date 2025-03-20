using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFactory.Class
{
    public class Material
    {
        public string Type { get; set; } // Тип материала
        public string Name { get; set; } // Наименование материала
        public int Quantity { get; set; } // Количество на складе
        public int SuppliersCount { get; set; } // Количество поставщиков
        public string Price { get; set; } // Текущая стоимость
        public int InitialMonthQuantity { get; set; } // Количество материалов на начало месяца
        public string Description { get; set; } // Описание
        public string Image { get; set; } // Изображение (путь к изображению)
        public string min_count { get; set; } // Минимальное количество
        public string ed_izm { get; set; } // Еденица измерения
    }
}
