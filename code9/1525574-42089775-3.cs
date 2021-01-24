    DateTime timepart = new DateTime(2017,2,7);
    DateTime datepart = new DateTime(2016, 8, 25, 10, 25, 0);
    string plannum = "995";
    
    using (DataSet1 dt = new DataSet1())
    {
         var res = (from row in Enumerable.AsEnumerable(dt.t)
              where row.plannum == plannum &&
              row.Date == datepart &&
              timepart >= row.MorningStart &&
              timepart < row.MorningEnd
              select row).Single();
    
    
         var found = res.MorningIsWorking;
         var shStartTime = res.MorningStart;
         var shEndTime = res.MorningEnd;
    }
