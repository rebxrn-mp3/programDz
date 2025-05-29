using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_15_zadanie
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
        $"Срок годности: {ExpiryDate:d}. Температура хранения: {StorageTemperature.ToString(CultureInfo.InvariantCulture)}°C"
            };
        }
    }
}
