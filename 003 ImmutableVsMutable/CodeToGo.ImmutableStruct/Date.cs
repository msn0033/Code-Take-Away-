﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeToGo.ImmutableStruct
{
    public struct Date
    {
        private static readonly int[] DaysOfMonthsNonLeap =
          { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private static readonly int[] DaysOfMonthLeap =
        { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public int Year { get; }
        public int Month { get; }
        public int Day { get; }

        public Date(int year, int month, int day)
        {

            if (year < 1 && year > 9999)
                throw new ArgumentOutOfRangeException(nameof(year));

            if (month < 1 && month > 12)
                throw new ArgumentOutOfRangeException(nameof(month));


            int[] days = IsLeapYear(year) ? DaysOfMonthLeap : DaysOfMonthsNonLeap;

            if (day < 1 || day > days[month])
                throw new ArgumentOutOfRangeException(nameof(day));

            Year = year;
            Month = month;
            Day = day;

        }


        public Date AddDays(int value)
        {
            // Cheating using DateTime
            var date = new DateTime(Year, Month, Day).AddDays(value);

            return new Date(date.Year, date.Month, date.Day);
        }

        public Date AddWeeks(int value)
        {
            return AddDays(value * 7);
        }

        public Date AddMonths(int value)
        {
            // Cheating using DateTime
            var date = new DateTime(Year, Month, Day).AddMonths(value);
         
            return new Date(date.Year, date.Month, date.Day);
        }
        public Date AddYears(int value)
        {
            // Cheating using DateTime
            var date = new DateTime(Year, Month, Day).AddYears(value);

            return new Date(date.Year, date.Month, date.Day);
        }

        public static bool IsLeapYear(int year)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException(nameof(year));
            }
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }


        public override string ToString()
        {
            return $"{Year}/{Month}/{Day}";
        }
    }
}
