            List<string> MyData = new List<string>();
            MyData.Add("4,500"); 
            MyData.Add("6,400");
    
            var months = Enumerable.Range(1, 12);
            foreach (int month in months)
            {
                if (MyData.Any(a =>  a.Split(',')[0] == month.ToString()))
                continue;
                MyData.Add(string.Format("{0},{1}", month.ToString(), "0"));
            }
