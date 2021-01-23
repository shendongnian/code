                List<double> testList = new List<double>();
    
                testList.Add(1);
                testList.Add(2.1);
                testList.Add(2.0);
                testList.Add(3.0);
                testList.Add(3.1);
                testList.Add(3.2);
                testList.Add(4.2);
                testList.Add(5.8);
                testList.Add(5.5);
    
                var testListGroup = testList.GroupBy(s => Math.Floor(s)).ToList();
