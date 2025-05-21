using System;
using System.Globalization;

namespace WarehouseLibrary
{
    public class FoodProduct : Commodity
    {
        public DateTime ExpiryDate { get; set; }
        public double StorageTemperature { get; set; }

        public FoodProduct(
            string article,
            string name,
            double weight,
            string dimensions,
            DateTime arrivalDate,
            decimal price,
            CommodityCharacteristic characteristic,
            int maxStack,
            DateTime expiryDate,
            double storageTemperature
        ) : base(article, name, weight, dimensions, arrivalDate, price, characteristic, maxStack)
        {
            ExpiryDate = expiryDate;
            StorageTemperature = storageTemperature;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            return new string[]
            {
        baseInfo[0],
        baseInfo[1],
        // Используйте InvariantCulture для температуры
        $"Срок годности: {ExpiryDate:d}. Температура хранения: {StorageTemperature.ToString(CultureInfo.InvariantCulture)}°C"
            };
        }
    }
}
