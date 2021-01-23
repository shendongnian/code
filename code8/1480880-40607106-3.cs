    Thread t = new Thread(() => 
            {
                foreach (var day in listOfDays)
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    double[] aData = GetDayData(data, day);
                    alData.Add(aData);
                    WriteLn("Processing " + day.Date.Date + " took " + watch.Elapsed.TotalSeconds + "s");
    
                    id++;
                }
            });
    
    t.Start();
