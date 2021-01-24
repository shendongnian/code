    private class MouseInfo {
        public readonly long TimeStamp;
        public readonly int PosX;
        public readonly int PosY;
        public int ButtonsDownFlag;
        public MouseInfo(long t, int x, int y, int flag) {
            TimeStamp = t;
            PosX = x;
            PosY = y;
            ButtonsDownFlag = flag;
        }
        public override string ToString() {
            return $"({TimeStamp:D2}: {PosX:D3}, {PosY:D4}, {ButtonsDownFlag})";
        }
    }
    public Program() {
        List<MouseInfo> mi = new List<MouseInfo>(14);
        mi.Add(new MouseInfo(1, 10, 100, 0));
        mi.Add(new MouseInfo(2, 20, 200, 1));
        mi.Add(new MouseInfo(3, 30, 300, 1));
        mi.Add(new MouseInfo(4, 40, 400, 0));
        mi.Add(new MouseInfo(5, 50, 500, 1));
        mi.Add(new MouseInfo(6, 60, 600, 0));
        mi.Add(new MouseInfo(7, 70, 700, 1));
        mi.Add(new MouseInfo(8, 80, 800, 1));
        mi.Add(new MouseInfo(9, 90, 900, 1));
        mi.Add(new MouseInfo(10, 100, 1000, 0));
        mi.Add(new MouseInfo(11, 110, 1100, 2));
        mi.Add(new MouseInfo(12, 120, 1200, 0));
        mi.Add(new MouseInfo(13, 130, 1300, 2));
        mi.Add(new MouseInfo(14, 140, 1400, 2));
        var groups = mi.GroupAdjacent(x => x.ButtonsDownFlag);
        List<List<MouseInfo>> drags = groups.Where(x => x.Key == 1 && x.Count() > 1).Select(x => x.ToList()).ToList();
        foreach (var d in drags) 
            foreach (var item in d)
                Console.Write($"{item} ");
        Console.WriteLine();
        List<List<MouseInfo>> clicks = groups.Where(x => x.Key > 1 || (x.Key == 1 && x.Count() == 1)).Select(x => x.ToList()).ToList();
        foreach (var d in clicks) {
            foreach (var item in d)
                Console.Write($"{item} ");
            Console.WriteLine();
        }
    }
    [MTAThread]
    static void Main(string[] args) {
        var x = new Program();
        Console.ReadLine();
        return;
    }
