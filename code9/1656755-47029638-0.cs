    //sample
            List<int> t1 = new List<int>();
            t1.Add(1);
            t1.Add(2);
            t1.Add(3);
        
            List<int> t2 = new List<int>();
            t2.Add(2);
        
            bool res = t2.Any(a => t1.Any(b => b == a));
            Console.WriteLine("res :" + res);
        // your solution here
        bool isSubset  = DB.Table.Any(s => localIdList.any(l=> l == s.ID));
