using System.Globalization;
using System.Xml.Linq;

namespace _13_15_zadanie
{
    public class Commodity : IComparable<Commodity>
    {

        public string Name { get; set; }
        public double Weight { get; set; }
        public string Dimensions { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal Price { get; set; }
        public int MaxStack { get; set; }

        public string Article { get; }
        public CommodityCharacteristic Characteristic { get; }

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

        public virtual string[] GetInfo()
        {
            return new string[]
            {
        $"{Article} - {Name}",
        $"Вес: {Weight.ToString(CultureInfo.InvariantCulture)} кг. " +
        $"Характеристика: {GetCharacteristicText()}. Макс. стопок: {MaxStack}"
            };
        }

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
        public int CompareTo(Commodity other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase);
        }
    }
}
