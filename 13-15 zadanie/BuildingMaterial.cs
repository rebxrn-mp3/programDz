using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_15_zadanie
{
    public class BuildingMaterial : Commodity
    {

        public bool CanBeStoredOutside { get; set; }


        public BuildingMaterial(
            string article,
            string name,
            double weight,
            string dimensions,
            DateTime arrivalDate,
            decimal price,
            CommodityCharacteristic characteristic,
            int maxStack,
            bool canBeStoredOutside
        ) : base(article, name, weight, dimensions, arrivalDate, price, characteristic, maxStack)
        {
            CanBeStoredOutside = canBeStoredOutside;
        }


        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            return new string[]
            {
                baseInfo[0],
                baseInfo[1],
                $"Хранение на открытой площадке: {(CanBeStoredOutside ? "Да" : "Нет")}"
            };
        }
    }
}