    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                "inputNames.txt".ReadFileAsLines()
                                .Select(l => l.Split(','))
                                .Select(l => new Person
                                {
                                    vorname = l[0],
                                    nachname = l[1],
                                    age = int.Parse(l[2]),
                                })
                                .OrderBy(p => p.age).ThenBy(p => p.nachname)
                                .WriteAsLinesTo("outputNames.txt");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
    public class Person
    {
        public string vorname { get; set; }
        public string nachname { get; set; }
        public int age { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}\t{2}", this.vorname, this.nachname, this.age);
        }
    }
    public static class ToolsEx
    {
        public static IEnumerable<string> ReadFileAsLines(this string filename)
        {
            using (var reader = new StreamReader(filename))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
        public static void WriteAsLinesTo(this IEnumerable lines, string filename)
        {
            using (var writer = new StreamWriter(filename))
                foreach (var line in lines)
                    writer.WriteLine(line);
        }
    }
