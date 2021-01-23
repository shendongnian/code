    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using LambdaSample.Extensions;
    using LambdaSample.Interfaces;
    namespace LambdaSample.Framework
    {
        /// <summary>
        /// Simple parser for text used in search fields for
        /// searching through records or any values
        /// </summary>
        public class PredicateParser : IPredicateParser
        {
            private enum RangeType
            {
                None,
                From,
                To
            }
            public PredicateParser()
            {
                Items = new List<IPredicateItem>();
            }
            public bool Parse(string text, bool rangesAllowed, Type definedType)
            {
                Items.Clear();
                if (string.IsNullOrWhiteSpace(text))
                    return true;
                var result = true;
                var items = text.Split(',');
                foreach (var item in items)
                {
                    object val1, val2;
                    bool isRange;
                    var ranges = item.Split('-');
                    if (rangesAllowed && ranges.Length == 2) // Range is only when ranges are allowed and length is 2, otherwise its single value.
                    {
                        object val1Temp, val2Temp;
                        if (ParseValue(ranges[0], definedType, RangeType.From, out isRange, out val1, out val1Temp) &&
                            ParseValue(ranges[1], definedType, RangeType.To, out isRange, out val2, out val2Temp))
                        {
                            Items.Add(new PredicateItemRange { Value1 = val1, Value2 = val2, });
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        if (ParseValue(item, definedType, RangeType.None, out isRange, out val1, out val2))
                        {
                            if (isRange)
                            {
                                Items.Add(new PredicateItemRange { Value1 = val1, Value2 = val2, });
                            }
                            else
                            {
                                Items.Add(new PredicateItemSingle { Value = val1, });
                            }
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                return result;
            }
            private bool ParseValue(string value, Type definedType, RangeType rangeType, out bool isRange, out object result, out object result2)
            {
                result = null;
                result2 = null;
                isRange = false;
                if (string.IsNullOrWhiteSpace(value))
                    return false;
                // Enums are also treated like ints!
                if (definedType == typeof(int) || definedType.IsEnum)
                {
                    int val;
                    if (!int.TryParse(value, out val))
                        return false;
                    result = val;
                    return true;
                }
                if (definedType == typeof(long))
                {
                    long val;
                    if (!long.TryParse(value, out val))
                        return false;
                    result = val;
                    return true;
                }
                if (definedType == typeof(decimal))
                {
                    decimal val;
                    if (!decimal.TryParse(value, NumberStyles.Number ^ NumberStyles.AllowThousands, new CultureInfo("sl-SI"), out val))
                        return false;
                    result = val;
                    return true;
                }
                if (definedType == typeof(DateTime))
                {
                    int year, month, yearMonth;
                    if (value.Length == 4 && int.TryParse(value, out year) && year >= 1000 && year <= 9999) // If only year, we set whole year's range (e.g. 2015 ==> 2015-01-01 00:00:00.0000000 - 2015-12-31 23:59:59.9999999
                    {
                        // Default datetime for From range and if no range
                        result = new DateTime(year, 1, 1);
                        switch (rangeType)
                        {
                            case RangeType.None:
                                result2 = ((DateTime)result).AddYears(1).AddMilliseconds(-1);
                                isRange = true;
                                break;
                            case RangeType.To:
                                result = ((DateTime)result).AddYears(1).AddMilliseconds(-1);
                                break;
                        }
                        return true;
                    }
                    if (value.Length == 6 && int.TryParse(value, out yearMonth) && yearMonth >= 100001 && yearMonth <= 999912) // If only year and month, we set whole year's range (e.g. 201502 ==> 2015-02-01 00:00:00.0000000 - 2015-02-28 23:59:59.9999999
                    {
                        year = Convert.ToInt32(yearMonth.ToString().Substring(0, 4));
                        month = Convert.ToInt32(yearMonth.ToString().Substring(4, 2));
                        // Default datetime for From range and if no range
                        result = new DateTime(year, month, 1);
                        switch (rangeType)
                        {
                            case RangeType.None:
                                result2 = ((DateTime)result).AddMonths(1).AddMilliseconds(-1);
                                isRange = true;
                                break;
                            case RangeType.To:
                                result = ((DateTime)result).AddMonths(1).AddMilliseconds(-1);
                                break;
                        }
                        return true;
                    }
                    DateTime val;
                    if (!value.ParseDateTimeEx(CultureInfo.InvariantCulture, out val))
                    {
                        return false;
                    }
                    if (val.Hour == 0 && val.Minute == 0)
                    {
                        // No hours and minutes specified, searching whole day or to the end of the day.
                        // If this is no range, we make it a range
                        result = new DateTime(val.Year, val.Month, val.Day);
                        switch (rangeType)
                        {
                            case RangeType.None:
                                result2 = ((DateTime)result).AddDays(1).AddMilliseconds(-1);
                                isRange = true;
                                break;
                            case RangeType.To:
                                result = ((DateTime)result).AddDays(1).AddMilliseconds(-1);
                                break;
                        }
                        return true;
                    }
                    result = val;
                    return true;
                }
                if (definedType == typeof(string))
                {
                    result = value;
                    return true;
                }
                return false;
            }
            public List<IPredicateItem> Items { get; private set; }
        }
    }
