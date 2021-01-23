    public class Data
    {
        public int id;
        public string name;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Data> l = new List<Data>
            {
                new Data { id = 1, name = "Name1"},
                new Data { id = 2, name = "Name2"},
                new Data { id = 3, name = "Name3"},
                new Data { id = 4, name = "Name4"},
                new Data { id = 5, name = "Name5"},
            };
            int id = 3;
            var result = l.Where(c => c.id == id)
                .Union(l.Where(c => c.id < id).OrderByDescending(c => c.id).Take(1))
                .Union(l.Where(c => c.id > id).OrderBy(c => c.id).Take(1)).ToList();
        }
    }
