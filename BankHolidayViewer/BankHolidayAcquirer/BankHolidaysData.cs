using Newtonsoft.Json;
using System;
using System.Linq;

namespace BankHolidayAcquisition
{
    public class BankHolidaysData
    {
        [JsonProperty(PropertyName = "england-and-wales")]
        public Country EnglandAndWales { get; set; }

        [JsonProperty(PropertyName = "scotland")]
        public Country Scotland { get; set; }

        [JsonProperty(PropertyName = "northern-ireland")]
        public Country NorthernIreland { get; set; }

        public class Country
        {
            public string division { get; set; }
            public Event[] events { get; set; }
        }

        public class Event
        {
            public string title { get; set; }
            public string date { get; set; }
            public string notes { get; set; }
            public bool bunting { get; set; }
        }

        public BankHoliday[] GetAllYearsBankHols(OriginCountry countryOfOrigin = OriginCountry.EnglandAndWales)
        {
            switch (countryOfOrigin)
            {
                case OriginCountry.EnglandAndWales:
                    return EnglandAndWales.events.Select(x => new BankHoliday(x.title, x.date))
                        .ToArray();

                case OriginCountry.Scotland:
                    return Scotland.events.Select(x => new BankHoliday(x.title, x.date))
                        .ToArray();

                case OriginCountry.NorthernIreland:
                    return NorthernIreland.events.Select(x => new BankHoliday(x.title, x.date))
                        .ToArray();

                default:
                    return EnglandAndWales.events.Select(x => new BankHoliday(x.title, x.date))
                        .ToArray();
            }
        }

        public DateTime[] GetAllYearsBankHolDates(OriginCountry countryOfOrigin = OriginCountry.EnglandAndWales)
        {
            switch (countryOfOrigin)
            {
                case OriginCountry.EnglandAndWales:
                    return EnglandAndWales.events.Select(x => DateTime.Parse(x.date))
                        .ToArray();

                case OriginCountry.Scotland:
                    return Scotland.events.Select(x => DateTime.Parse(x.date))
                        .ToArray();

                case OriginCountry.NorthernIreland:
                    return NorthernIreland.events.Select(x => DateTime.Parse(x.date))
                        .ToArray();

                default:
                    return EnglandAndWales.events.Select(x => DateTime.Parse(x.date))
                        .ToArray();
            }
        }

        public enum OriginCountry
        {
            EnglandAndWales,
            Scotland,
            NorthernIreland
        }
    }
}