using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_15_zadanie
{
    public class Shipment : IEnumerable<Commodity>
    {
        public string Supplier { get; }
        public string ShipmentNumber { get; }
        public DateTime ShipmentDate { get; }
        private List<Commodity> _commodities;

        public Shipment(string supplier, string shipmentNumber, DateTime shipmentDate, IEnumerable<Commodity> commodities)
        {
            Supplier = supplier;
            ShipmentNumber = shipmentNumber;
            ShipmentDate = shipmentDate;
            _commodities = new List<Commodity>();

            foreach (var item in commodities)
            {
                if (!_commodities.Contains(item))
                    _commodities.Add(item);
            }
        }

        public IEnumerator<Commodity> GetEnumerator() => _commodities.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void AddCommodity(Commodity commodity)
        {
            if (!_commodities.Contains(commodity))
                _commodities.Add(commodity);
        }

        public void RemoveCommodity(Commodity commodity)
        {
            _commodities.Remove(commodity);
        }
    }
}