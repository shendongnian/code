    public class Page
        {
            public Page Child { get; set; }
            public string PageNumber { get; set; }
        }
        private static void Main()
        {
            var page1 = new Page {PageNumber = "1"};
            var page2 = new Page {PageNumber = "2"};
            var page3 = new Page {PageNumber = "3"};
            page1.Child = page2;
            page2.Child = page3;
           
            var x = page1.Child.Child.PageNumber;
            Console.WriteLine(x);
        }
