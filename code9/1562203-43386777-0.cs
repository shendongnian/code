        static void Main(String[] args) {
            var lines = File.ReadAllLines(args[0]);
            lines.OrderByDescending(s => s.Split().Count());
            File.WriteAllLines(args[0], lines);
        }
