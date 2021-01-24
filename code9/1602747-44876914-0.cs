            public static List<Table> TestFunction(Filters pParameter)
        {
            ExampleDataContext dc = new ExampleDataContext(Properties.Settings.Default.ExampleConnectionString);
            var SelectResult = dc.Table;
            
            if (pParameter.A.count != 0)
                SelectResult = from x in SelectResult 
                               where pParameter.A.Contains(x.A)
                               select x;
            if (pParameter.B.count != 0)
            {
                SelectResult = from x in SelectResult
                               where pParameter.B.Contains(x.B)
                               select x;
            }
            return SelectResult.ToList();
        }
