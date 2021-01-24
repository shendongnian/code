    var lst = (from t in context.MT_LineClass
                           where t.ProjectId == projId
                           group t by t.LineClass into g
                           select new Mt_Lineclass
                           {
                               lineId = g.Select(t => t.LineClassId).FirstOrDefault(),
                               Lineclass = g.Select(t => t.LineClass).FirstOrDefault()
                           }).ToList(); 
