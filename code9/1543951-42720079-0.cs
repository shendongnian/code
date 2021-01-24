    public static Dictionary<int, int[]> Dict = new Dictionary<int, int[]>();
    private static int hitcount = 0;
    static void Main(string[] args)
    {
        //Example data
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Dict.Add(1, new int[] { 2, 3, 4 });
        Dict.Add(2, new int[] { 3, 6 });
        Dict.Add(3, new int[] { 5, 6 });
        Dict.Add(4, new int[] { 2, 3 });
        Dict.Add(5, new int[] { 6 });
        Dict.Add(6, new int[] { });
        var links = GetAllLinks(1);
        foreach (var link in links)
        {
            Console.WriteLine(link.ToString());
        }
        sw.Stop();
        Console.WriteLine("MS:" + sw.ElapsedMilliseconds + " - " + hitcount);
        Console.ReadKey();
    }
    private static List<int> GetLinksFromKey(int key)
    {
        //This usually takes avg 800ms so sleep here
        //This is the BottleNeck, the more often its called longer it will take
        Thread.Sleep(0);
        hitcount++;
        return Dict[key].ToList();
    }
    private static List<int> GetAllLinks(int key)
    {
        var alreadyDone = new HashSet<int>();
        var workingOn = new HashSet<int>();
        var pages = new List<int>();
        RecursiveGetAllLinks(pages, alreadyDone, workingOn, key);
        return pages;
    }
    private static void RecursiveGetAllLinks(List<int> pages, HashSet<int> alreadyDone, HashSet<int> workingOn, int key)
    {
        if (!workingOn.Add(key))
        {
            throw new Exception("Recursion for " + key);
        }
        var links = GetLinksFromKey(key);
        foreach (int link in links)
        {
            if (alreadyDone.Contains(link))
            {
                continue;
            }
            RecursiveGetAllLinks(pages, alreadyDone, workingOn, link);
        }
        alreadyDone.Add(key);
        pages.Add(key);
        workingOn.Remove(key);
    }
