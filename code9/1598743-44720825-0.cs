    public class Data
    {
        public string Date { get; set; }
        public int OkRecords { get; set; }
        public int ErrorRecords { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<string> distinctDates = new List<string>();
            for (int i = 0; i < 10000; i++)
            {
                distinctDates.Add( rand.Next(1, 12) + "/" + rand.Next(1, 30) + "/1");
            }
            List<Data> dataList = new List<Data>(); 
            for (int i = 0; i < 10000; i++)
            {
                dataList.Add(new Data{ Date = rand.Next(1,12)+"/"+rand.Next(1, 30)+"/1", OkRecords=0, ErrorRecords=1});
            }
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Method1(distinctDates, dataList);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            watch.Reset();
            watch.Start();
            Method2(distinctDates, dataList);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            Console.ReadLine();
        }
        private static void Method1(List<string> distinctDates, List<Data> dataList)
        {
            List<Data> DataListCombined = new List<Data>();
            int distinctDatesCount = distinctDates.Count;
            for (int i = 0; i < distinctDatesCount; i++)
            {
                string date = distinctDates[i];
                int ok = 0, error = 0;
                foreach (var item in dataList.Where(w => w.Date == date))
                {
                    ok += item.OkRecords;
                    error += item.ErrorRecords;
                }
                Data dataValues = new Data
                {
                    Date = date,
                    OkRecords = ok,
                    ErrorRecords = error
                };
                DataListCombined.Add(dataValues);
            }
        }
        private static void Method2(List<string> distinctDates, List<Data> dataList)
        {
            List<Data> DataListCombined = distinctDates.GroupJoin(
                dataList,
                distinctDateItem => distinctDateItem,
                dataListItem => dataListItem.Date,
                (dataListItem, distinctDateItems) => new Data
                {
                    ErrorRecords = distinctDateItems.Sum(item => item.ErrorRecords),
                    OkRecords = distinctDateItems.Sum(item => item.OkRecords),
                    Date = dataListItem
                }
                ).ToList();
        }
    }
