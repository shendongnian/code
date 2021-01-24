    static void Main(string[] args)
    {
       List<Myclas> listy = new List<Myclas>();
       listy.Add(new Myclas { name = "a", id = 1, color = "blue" });
       listy.Add(new Myclas { name = "b", id = 1, color = "yellow" });
       var result = listy.FirstOrDefault(t => t.color == "yellow");
    }
