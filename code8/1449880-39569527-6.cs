        class MyClass
        {
            public string Myname { get; set; }
        }
        static void Main(string[] args)
        {
            var check = new MyClass() { Myname = "11 aa 22" };
            var check2 = new MyClass() { Myname = "11 bb 22" };
            var x = new List<MyClass>();
            x.Add(check);
            x.Add(check2);
            var q = x.AsQueryable();
            var qry = Test(q, "Myname", "bb");
        }
