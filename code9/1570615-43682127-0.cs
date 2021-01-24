    class Program
    {
        class grpitem
	    {
	        public string groupCode;
	        public string item;
	    }
        static List<grpitem> list = new List<grpitem>()
        {
             new grpitem() {groupCode="3", item="b"},
             new grpitem() {groupCode="1", item="b"},
             new grpitem() {groupCode="3", item="c"},
             new grpitem() {groupCode="2", item="b"},
             new grpitem() {groupCode="2", item="a"},
             new grpitem() {groupCode="2", item="c"},
             new grpitem() {groupCode="1", item="a"},
             new grpitem() {groupCode="3", item="a"},
             new grpitem() {groupCode="3", item="d"}
        };
        static void Main(string[] args)
        {
            IEnumerable<grpitem> ordered = list.GroupBy(grp => grp.groupCode)
                .SelectMany(g => g.OrderBy(grp => grp.item)).OrderBy(g => g.groupCode);
 
	        foreach(grpitem g in ordered)
	            Console.WriteLine("groupCode:{0} item:{1}",g.groupCode,g.item);
            Console.ReadLine();
        }
    }
