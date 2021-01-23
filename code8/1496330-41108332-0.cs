        class Sites
        {
            public string Year { get; set; }
        }
        class MainClass
        {
            static void Main()
            {
                List<Sites> ListOfSites = new List<Sites>();
                ListOfSites.Add(new Sites { Year = "01/2012" });
                ListOfSites.Add(new Sites { Year = "04/2012" });
                ListOfSites.Add(new Sites { Year = "01/2013" });
                ListOfSites.Add(new Sites { Year = "06/2012" });
    
                DateTime SiteYear;
                List<DateTime> listWithDates = new List<DateTime>(); 
    
                foreach (var item in ListOfSites)
                {
                    if(DateTime.TryParse(item.Year, out SiteYear))
                    {
                        listWithDates.Add(SiteYear);
                    }
                }
                Display(SortAscending(listWithDates), "Sort Ascending");
    
            }
            static List<DateTime> SortAscending(List<DateTime> list)
            {
                list.Sort((a, b) => a.CompareTo(b));
                return list;
            }
            static void Display(List<DateTime> list, string message)
            {
                Console.WriteLine(message);
                foreach (var datetime in list)
                {
                    Console.WriteLine(datetime);
                }
                Console.WriteLine();
            }
        }
