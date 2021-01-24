    using Microsoft.Recognizers.Text;
    using Microsoft.Recognizers.Text.DateTime;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace RecognizerDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    string Query = string.Empty;
                    Console.WriteLine("Enter date: ");
                    Query = Console.ReadLine();
                    DateTime parsedDate = ExtractDateFromNaturalLanguage(Query);
                    List<DateTime> futureDates = GetSubsequentDateTimes(parsedDate);
    
    
                    foreach (var item in futureDates)
                    {
                        Console.WriteLine(item.ToLongDateString());
                    }
    
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Failed because: {ex.Message}");
                }
            }
    
        static List<DateTime> GetSubsequentDateTimes(DateTime date)
        {
            try
            {
                List<DateTime> futureDates = new List<DateTime>();
                DayOfWeek dayOfWeekOriginalDate = date.DayOfWeek;
                int month = date.Month;
                futureDates.Add(date);
                for (int i = month + 1; i <= month + 5; i++)
                {
                    DateTime dt = new DateTime(date.Year, i, 1);
                   
                    while (dt.DayOfWeek != dayOfWeekOriginalDate)
                    {
                        dt = dt.AddDays(1);
                    }
                    futureDates.Add(dt);
                }
                return futureDates;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
            static DateTime ExtractDateFromNaturalLanguage(string Query)
            {
                try
                {
                    DateTimeModel model = DateTimeRecognizer.GetInstance().GetDateTimeModel(Culture.English);
                    List<ModelResult> parsedResults = model.Parse(Query);
    
                    Dictionary<string, string> resolvedValue = (parsedResults.SelectMany(x => x.Resolution).FirstOrDefault().Value as List<Dictionary<string, string>>).FirstOrDefault();
    
                    string parsedDate = string.Empty;
    
                    if (resolvedValue["type"] == "daterange")
                        parsedDate = resolvedValue["start"];
    
                    if (resolvedValue["type"] == "date")
                        parsedDate = resolvedValue["value"];
    
                    DateTime parsedDateTimeObject = DateTime.Parse(parsedDate);
    
                    return parsedDateTimeObject;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
