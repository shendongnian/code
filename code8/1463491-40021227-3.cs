    class Thingy
    {
        public int Number { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Thingy> list = new List<Thingy>() { new Thingy { Number = 500 } };
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(list))
            {
                table.Load(reader);
            }
        }
    }
