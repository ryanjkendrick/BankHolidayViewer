using Newtonsoft.Json;

using System;
using System.Linq;
using System.Net;

using static BankHolidayAcquisition.BankHolidaysData;

namespace BankHolidayAcquisition
{
    public class BankHolidayAcquirer
    {
        public BankHoliday[] GetThisYearsBankHols(OriginCountry countryOfOrigin = OriginCountry.EnglandAndWales)
        {
            BankHolidaysData bankHolData = GetBankHolData();
            BankHoliday[] bankHols = bankHolData.GetAllYearsBankHols(countryOfOrigin);

            return bankHols.Where(x => x.Date.Year == DateTime.Now.Year).ToArray();
        }

        public DateTime[] GetThisYearsBankHolDates(OriginCountry countryOfOrigin = OriginCountry.EnglandAndWales)
        {
            BankHolidaysData bankHolData = GetBankHolData();
            DateTime[] bankHols = bankHolData.GetAllYearsBankHolDates(countryOfOrigin);

            return bankHols.Where(x => x.Year == DateTime.Now.Year).ToArray();
        }

        public BankHoliday[] GetNextYearsBankHols(OriginCountry countryOfOrigin = OriginCountry.EnglandAndWales)
        {
            BankHolidaysData bankHolData = GetBankHolData();
            BankHoliday[] bankHols = bankHolData.GetAllYearsBankHols(countryOfOrigin);

            return bankHols.Where(x => x.Date.Year == DateTime.Now.Year + 1).ToArray();
        }

        public DateTime[] GetNextYearsBankHolDates(OriginCountry countryOfOrigin = OriginCountry.EnglandAndWales)
        {
            BankHolidaysData bankHolData = GetBankHolData();
            DateTime[] bankHols = bankHolData.GetAllYearsBankHolDates(countryOfOrigin);

            return bankHols.Where(x => x.Year == DateTime.Now.Year + 1).ToArray();
        }

        public BankHoliday[] GetLastYearsBankHols(OriginCountry countryOfOrigin = OriginCountry.EnglandAndWales)
        {
            BankHolidaysData bankHolData = GetBankHolData();
            BankHoliday[] bankHols = bankHolData.GetAllYearsBankHols(countryOfOrigin);

            return bankHols.Where(x => x.Date.Year == DateTime.Now.Year - 1).ToArray();
        }

        public DateTime[] GetLastYearsBankHolDates(OriginCountry countryOfOrigin = OriginCountry.EnglandAndWales)
        {
            BankHolidaysData bankHolData = GetBankHolData();
            DateTime[] bankHols = bankHolData.GetAllYearsBankHolDates(countryOfOrigin);

            return bankHols.Where(x => x.Year == DateTime.Now.Year - 1).ToArray();
        }

        public BankHoliday[] GetSpecifiedYearsBankHols(int year, OriginCountry countryOfOrigin = OriginCountry.EnglandAndWales)
        {
            BankHolidaysData bankHolData = GetBankHolData();
            BankHoliday[] bankHols = bankHolData.GetAllYearsBankHols(countryOfOrigin);

            if (!bankHols.Any(x => x.Date.Year == year))
                throw new ArgumentOutOfRangeException();

            return bankHols.Where(x => x.Date.Year == year).ToArray();
        }

        public DateTime[] GetSpecifiedYearsBankHolDates(int year, OriginCountry countryOfOrigin = OriginCountry.EnglandAndWales)
        {
            BankHolidaysData bankHolData = GetBankHolData();
            DateTime[] bankHols = bankHolData.GetAllYearsBankHolDates(countryOfOrigin);

            if (!bankHols.Any(x => x.Year == year))
                throw new ArgumentOutOfRangeException();

            return bankHols.Where(x => x.Year == year).ToArray();
        }

        public BankHolidaysData GetBankHolData()
        { 
            return JsonConvert.DeserializeObject<BankHolidaysData>(GetBankHolDataJSON());
        }

        public string GetBankHolDataJSON()
        {
            string json;

            using (WebClient client = new WebClient())
            {
                json = client.DownloadString("https://www.gov.uk/bank-holidays.json");
            }

            return json;
        }
    }
}