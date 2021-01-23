    static void Main(string[] args)
            {
                List<DataModel> models = new List<DataModel>();
                var lines = File.ReadLines("C:\\Temp\\PASS-FAIL STATUS.txt").ToArray();
    
                for(int i = 0; i < lines.Count(); i = i + 3)
                {
                    var number = lines[i].Replace("Number:", "");
                    var status = lines[i+1].Replace("Status:", "");
                    var dateTime = lines[i+2].Replace("Date:", "");
    
                    models.Add(new DataModel {
                        Number = number,
                        Status = status,
                        Date = DateTime.ParseExact(dateTime, "M/d/yyyy h:m tt", System.Globalization.CultureInfo.InvariantCulture)
                    });
                }
    
                Console.ReadKey();
            }
    
            public class DataModel
            {
                public string Number { get; set; }
                public string Status { get; set; }
                public DateTime Date { get; set; }
            } 
