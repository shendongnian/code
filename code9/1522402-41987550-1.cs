        static void Main(string[] args)
        {
            using (var ctx = new TestContext())
            {
                // for testing to see al working 
                //this is important to read the entity first .
                var parent = ctx.Lists.ToList();
                foreach (var p in parent)
                {
                    foreach (var child in p.MyListChildren)
                    {
                        Console.WriteLine(string.Format(@"Parent Name {0}  has child with name {1}", p.Name, child.Name));
                    }
                }
            }
            Console.ReadLine();
        }
