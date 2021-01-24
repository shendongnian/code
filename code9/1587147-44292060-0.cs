    var pts = (from pt in context.PT
              join ch in context.CH on pt.PTId equals ch.PTId
              select new {
                  PTCol1 = pt.Col1, 
                  CHCol1 = ch.CHCol1
                  // select other columns here...
              }).ToList();
    var ptsStringCollection = pts.Select(p => string.Format("{0},{1}", p.PTCol1, p.CHCol1);
