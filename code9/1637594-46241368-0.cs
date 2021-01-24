    class Program
    {
        static void Main(string[] args)
        {
           
            List<data> datas = new List<data>();
            
            datas.Add(new data() {atricle = "ART1", price = 99});
            datas.Add(new data() { atricle = "ART2", price = 100 });
            datas.Add(new data() { atricle = "ART3", price = 150 });
            datas.Add(new data() { atricle = "ART2", price = 90 });
            datas.Add(new data() { atricle = "ART1", price = 50 });
            Console.WriteLine($"Atricle | Duplicates");
            foreach (data templist in datas)
            {
                var duplicates = datas.Select((data, index) => new {atricle = data.atricle, Index = index + 1})
                    .Where(x => x.atricle == templist.atricle)
                    .GroupBy(pair => pair.atricle)
                    .Where(g => g.Count() > 1)
                    .Select(grp => grp.Select(g => g.Index.ToString()).ToArray())
                    .ToArray();
                string joined = duplicates.Length>0 ? string.Join(",", duplicates[0].ToList()):"";
                Console.WriteLine($"{templist.atricle} | {joined}");               
            }
            Console.ReadLine();
        }
    }
