using System;
using System.Globalization;
namespace WarehouseLibrary
{
    public class Commodity
    {
        // Свойства, передаваемые через конструктор (отмечены точкой в задании)
        public string Name { get; set; }                // Наименование
        public double Weight { get; set; }              // Вес (кг)
        public string Dimensions { get; set; }          // Габариты (длина x ширина x высота)
        public DateTime ArrivalDate { get; set; }       // Дата поступления
        public decimal Price { get; set; }              // Цена
        public int MaxStack { get; set; }               // Особенности складирования (макс. стопок)

        // Свойства только для чтения
        public string Article { get; }                  // Артикул (только для чтения)
        public CommodityCharacteristic Characteristic { get; } // Характеристика (перечисление)

        // Конструктор
        public Commodity(string article, string name, double weight, string dimensions,
                         DateTime arrivalDate, decimal price, CommodityCharacteristic characteristic,
                         int maxStack)
        {
            Article = article;
            Name = name;
            Weight = weight;
            Dimensions = dimensions;
            ArrivalDate = arrivalDate;
            Price = price;
            Characteristic = characteristic;
            MaxStack = maxStack;
        }

        // Метод GetInfo()
        public virtual string[] GetInfo()
        {
            return new string[]
            {
        $"{Article} - {Name}",
        $"Вес: {Weight.ToString(CultureInfo.InvariantCulture)} кг. Характеристика: {GetCharacteristicText()}. Макс. стопок: {MaxStack}"
            };
        }

        // Вспомогательный метод для перевода перечисления в текст
        private string GetCharacteristicText()
        {
            switch (Characteristic)
            {
                case CommodityCharacteristic.Ordinary:
                    return "Обыкновенный";
                case CommodityCharacteristic.Fragile:
                    return "Хрупкий";
                case CommodityCharacteristic.MoistureSensitive:
                    return "Боится сырости";
                default:
                    return "Неизвестно";
            }
        }
    }
}
