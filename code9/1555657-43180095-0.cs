    class Program
    {
        string EndpointUri = "{endpoint URL}";
        string PrimaryKey = "{primary key}";
        DocumentClient client;
    
        static void Main(string[] args)
        {
            BulkDateInsert item = new BulkDateInsert() { CalendarDate = @"\/Date(1490985000000)\/", Calendarday = "Sat", isweekday = false, isweekend = true };
            BulkDateInsert item1 = new BulkDateInsert() { CalendarDate = @"\/Date(1491071400000)\/", Calendarday = "Sun", isweekday = false, isweekend = true };
            List<BulkDateInsert> list = new List<BulkDateInsert>();
            list.Add(item);
            list.Add(item1);
    
            IList<BulkDateInsert> objExcelCon= list;
    
            GroupedData gdata = new GroupedData() { Calendardata = objExcelCon };
    
           Program p = new Program();
    
            p.CreateDocumentForCalendarData(gdata).Wait();
        }
    
        private async Task CreateDocumentForCalendarData(GroupedData ParsedJson)
        {
            this.client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
    
            await client.CreateDocumentAsync("dbs/{dbname}/colls/{collectionname}", ParsedJson);
        }
    
    public class GroupedData {
    
        //could be weekly, monthly data
            public IList<BulkDateInsert> Calendardata { get; set; }
        }
    
        public class BulkDateInsert
        {
            public string CalendarDate { get; set; }
            public string Calendarday { get; set; }
            public bool isweekday { get; set; }
            public bool isweekend { get; set; }
        }
    }
