    public class CensusRecord
    {
        public int Age {get;set;}
        public int DistrictID {get;set;}
        public bool DataReady {get;private set;}
        public static CensusRecord FromDataLine(string line)
        {
           // I don't normally recommend .Split() for CSV data -- too many edge cases
           //  -- but this didn't seem like the time to pull in a CSV reader
           var fields = line.Split(','); 
           int age = 0, district = 0;
           var result = new CensusRecord();
           result.DataReady = true;
           if (int.TryParse(fieldsArray[0], out age))
               result.Age = age;
           else
               result.DataReady = false;
           if (int.TryParse(fieldsArray[3], out district))
               result.DistrictID = district;
           else
               result.DataReady = false;
            return result;          
        }
    }
    class Program
    {
        static IEnumerable<CensusRecord> LoadData(string filename)
        {
            return File.ReadLines(filename)
                 .Select(line => CensusRecord.FromDataLine(line))
                 .Where(r => r.DataReady);
        }
        static void Main(string[] args)
        {
            var data = LoadData("censusdata.txt").ToList();
            DisplayDistrictPopulations(data);
            Console.WriteLine("");
            DisplayAgeGroups(data);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
        static void DisplayDistrictPopulations(IEnumerable<CensusRecord> data)
        {
            foreach(var district in data.GroupBy(r => r.DistrictID).OrderBy(g => g.Key))
            {
                 Console.WriteLine("District {0}: Population = {1}", district.Key, district.Count());
            }
        }
        static void DisplayAgeGroups(IEnumerable<CensusRecord> data)
        {
            var groups = data.GroupBy(r => {
                if (r.Age <  18) return 0;
                if (r.Age <= 30) return 1;
                if (r.Age <= 45) return 2;
                if (r.Age <= 64) return 3;
                return 4;
              }).OrderBy(g => g.Key);
            string[] ageStrings = {"Age Under 18", "Ages 18-30","Ages 31-45", "Ages 46-64", "65 & Over"};
            foreach (var age in groups)
            {
                Console.WriteLine("{0}: Population = {1}", ageStrings[age.Key], age.Count());
            }
        }
    }
    
 
