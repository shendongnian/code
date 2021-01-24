    public class Foo { }
    
            public class Bar { }
    
            public void sample()
            {
                var sql = "select * from Foo; select * from Bar";
                var foosAndBars = this.GetMultiple(sql, new { param = "baz" }, gr => gr.Read<Foo>(), gr => gr.Read<Bar>());
                var foos = foosAndBars.Item1;
                var bars = foosAndBars.Item2;
            }
