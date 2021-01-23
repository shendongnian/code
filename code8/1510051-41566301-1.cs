    public class Data
    {
        public int id;
        public string name;
        public DateTime date;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Data> l = new List<Data>
            {
                new Data { id = 1, name = "Name1", date = DateTime.Parse("2017/01/01")},
                new Data { id = 2, name = "Name2", date = DateTime.Parse("2017/01/03")},
                new Data { id = 3, name = "Name3", date = DateTime.Parse("2017/01/02")},
                new Data { id = 4, name = "Name4", date = DateTime.Parse("2017/01/04")},
                new Data { id = 5, name = "Name5", date = DateTime.Parse("2017/01/05")},
            };
            int id = 2;
            var result = l.Where(c => c.id == id)
                .Union(l.Where(c => c.date < l.Where(t => t.id == id).Select(d => d.date).First()).OrderByDescending(c => c.date).Take(1))
                .Union(l.Where(c => c.date > l.Where(t => t.id == id).Select(d => d.date).First()).OrderBy(c => c.date).Take(1)).ToList();
        }
    }
