    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Holiday holiday = new Holiday();
                foreach (Holiday day in Holiday.holidays)
                {
                    foreach (object field in  new HolidayField(day))
                    {
                        int a = 1;
                    }
                    HolidayField hf = new HolidayField(day);
                    for (HolidayField.Field field = HolidayField.Field.HOLIDAY_DATE; field < HolidayField.Field.END; field++)
                    {
                        object o = hf.GetEnumerator(field);
                    }
                }
                var groups = Holiday.holidays.GroupBy(x => x.HolidayDate).ToList();
     
            }
        }
        public class HolidayField : IEnumerator, IEnumerable
        {
            public Holiday holiday;
            
            public enum Field
            {
                RESET,
                HOLIDAY_DATE,
                DESCRIPTION,
                REPLACEMENT_DATE,
                END
            }
            Field _holidayProperties;
            
            public HolidayField(Holiday holiday)
            {
                this.holiday = holiday;
            }
            public Field GetIndex()
            {
                return _holidayProperties;
            }
            public object GetEnumerator(Field field)
            {
                return GetCurrent(holiday, field);
            }
            public HolidayField GetEnumerator()
            {
                return this;
            }
            // Implementation for the GetEnumerator method.
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator) GetEnumerator();
            }
     
            public object Current
            {
                get
                {
                    return GetCurrent(holiday, _holidayProperties);
                }
            }
            public object GetCurrent(Holiday holiday, Field field)
            {
                object results = null;
                switch (field)
                {
                    case Field.DESCRIPTION:
                        results = (object)holiday.Description;
                        break;
                    case Field.HOLIDAY_DATE:
                        results = (object)holiday.HolidayDate;
                        break;
                    case Field.REPLACEMENT_DATE:
                        results = (object)holiday.ReplacementDate;
                        break;
                }
                return results;
            }
            public bool MoveNext()
            {
                _holidayProperties += 1;
                return _holidayProperties == Field.END ? false : true;
            }
            public void Reset()
            {
                _holidayProperties = Field.RESET;
            }
            public void Dispose()
            {
            }
        }
        public class Holiday
        {
            public static List<Holiday> holidays = new List<Holiday>()
            {
                new Holiday(new DateTime(2016,1,1),"NEW YEAR 2016"),
                new Holiday(new DateTime(2016,3,27),"EASTER MONDAY 2016", new DateTime(2016,3,28)),
                new Holiday(new DateTime(2016,12,25),"CHRISTMAS DAY 2016", new DateTime(2016,12,26)),
                new Holiday(new DateTime(2017,1,1),"NEW YEAR 2017", new DateTime(2017,1,2)),
                new Holiday(new DateTime(2017,4,17),"EASTER MONDAY 2017"),
                new Holiday(new DateTime(2017,12,25),"CHRISTMAS DAY 2017"),
                new Holiday(new DateTime(2018,1,1),"NEW YEAR 2018"),
                new Holiday(new DateTime(2018,1,1),"DUPLICATE 1"), //example of a duplicate
                new Holiday(new DateTime(2018,1,2),"DUPLICATE 2", new DateTime(2016,1,1)), //example of a duplicate
                new Holiday(new DateTime(2018,1,3),"DUPLICATE 3", new DateTime(2017,1,2)), //example of a duplicate
                new Holiday(new DateTime(2018,1,4),"DUPLICATE 4", new DateTime(2018,1,4)), //example of a duplicate
            };
            public DateTime HolidayDate { get; set; }
            public string Description { get; set; }
            public DateTime? ReplacementDate { get; set; }
            public Holiday() { }
            public Holiday(DateTime hDate, string descr, DateTime? rDate = null)
            {
                HolidayDate = hDate;
                Description = descr;
                ReplacementDate = rDate;
            }
        }
    }
