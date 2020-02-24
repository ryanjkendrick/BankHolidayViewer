using System;

namespace BankHolidayAcquisition
{
    public class BankHoliday
    {
        public BankHoliday(string name, string date)
        {
            Name = name;
            Date = DateTime.Parse(date);
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}