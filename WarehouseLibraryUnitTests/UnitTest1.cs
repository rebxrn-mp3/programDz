using NUnit.Framework;
using WarehouseLibrary;
using System;

namespace WarehouseLibrary.UnitTests
{
    [TestFixture]
    public class CommodityUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var commodity = CreateTestCommodity();
            Assert.That(commodity.Article, Is.EqualTo("ART-001"));
            Assert.That(commodity.Name, Is.EqualTo("Лампа"));
            Assert.That(commodity.Weight, Is.EqualTo(0.5));
            Assert.That(commodity.Dimensions, Is.EqualTo("10x10x20"));
            Assert.That(commodity.Characteristic, Is.EqualTo(CommodityCharacteristic.Fragile));
        }

        [Test]
        public void GetInfoTest()
        {
            var commodity = CreateTestCommodity();
            var info = commodity.GetInfo();
            Assert.That(info[0], Is.EqualTo("ART-001 - Лампа"));
            Assert.That(info[1], Is.EqualTo("Вес: 0.5 кг. Характеристика: Хрупкий. Макс. стопок: 5"));
        }

        private Commodity CreateTestCommodity()
        {
            return new Commodity(
                article: "ART-001",
                name: "Лампа",
                weight: 0.5,
                dimensions: "10x10x20",
                arrivalDate: new DateTime(2023, 10, 1),
                price: 1500m,
                characteristic: CommodityCharacteristic.Fragile,
                maxStack: 5
            );
        }
    }
}