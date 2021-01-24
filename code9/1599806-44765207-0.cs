       static void Main(string[] args)
        {
            var list= new List<Class1>();
            var class1 = new Class1 {P1 = "P1-1", P2 = "P2-1", P3="null"};
            list.Add(class1);
            var class2 = new Class1 { P1 = "P1-2", P2 = "P2-2", P3 = "null" };
            list.Add(class2);
            foreach (var item in list)
            {
                var props2 = from p in item.GetType().GetProperties()
                            let attr = p.GetValue(item)
                            where attr != null && attr.ToString() == "null"
                            select p;
                foreach (var i in props2)
                {
                    i.SetValue(item, string.Empty);
                }
            }
        }
