        //You should allways reuse the regex objects since createing them can be slow
            private static readonly Regex regex = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
    
            static void Main(string[] args)
            {
                //Some csv data
                var csv =
    @"H1,H2,H3
    1,""ASd, asdasd, asda"", asd
    1,""ASd, asdasd, asda"", asd
    1,""ASd, asdasd, asda"", asd";
    
                //Gets the lines from csv you can use the ReadAllLines
                var lines = csv.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    
                //In csv the first row can indicate the headers like in you case
                var headers = regex.Split(lines.First()).Select((name,index) => new { name, index });
    
                //Skip Header data and split the rest of the string
                var items = from line in lines.Skip(1)
                            let data = regex.Split(line)
                            select headers.ToDictionary(i => i.name, i=> data[i.index]);
    
                //Simple way to create JSON string can be optimised if you need high performance
                Console.WriteLine(JsonConvert.SerializeObject(items, Formatting.Indented));
    
                Console.ReadLine();
            }
