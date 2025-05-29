using NUnit.Framework;
using WarehouseLibrary;
using System;
using _13_15_zadanie;

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
        [Test]
        public void FoodProduct_GetInfo_ReturnsThreeLines()
        {
            var food = new FoodProduct(
                article: "ART-002",
                name: "Молоко",
                weight: 1.2,
                dimensions: "10x10x20",
                arrivalDate: new DateTime(2023, 10, 1),
                price: 100m,
                characteristic: CommodityCharacteristic.Fragile,
                maxStack: 3,
                expiryDate: new DateTime(2023, 12, 31),
                storageTemperature: 4.5
            );

            var info = food.GetInfo();
            Assert.That(info.Length, Is.EqualTo(3)); 
            Assert.That(info[2], Is.EqualTo("Срок годности: 31.12.2023. Температура хранения: 4.5°C"));
        }

        [Test]
        public void BuildingMaterial_GetInfo_ReturnsThreeLines()
        {
            var material = new BuildingMaterial(
                article: "ART-003",
                name: "Кирпич",
                weight: 2.5,
                dimensions: "20x10x5",
                arrivalDate: new DateTime(2023, 10, 1),
                price: 50m,
                characteristic: CommodityCharacteristic.Ordinary,
                maxStack: 10,
                canBeStoredOutside: true
            );

            var info = material.GetInfo();
            Assert.That(info.Length, Is.EqualTo(3)); 
            Assert.That(info[2], Is.EqualTo("Хранение на открытой площадке: Да"));
        }
    }
}