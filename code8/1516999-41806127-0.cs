      public class DbOBject
        {
            public string Id { get { return BusinessValue + "_" + Type.ToString(); } }
            public string Name { get; set; }
            public string BusinessValue{ get; set; }
            public int Type { get; set; }
       }
