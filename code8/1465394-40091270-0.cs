    public ActionResult Details(int? id)
    {
         ReportViewModel rvm = new ReportViewModel();
         tblReport Report = db.tblReports.Find(id);
         List<tblDBTablesUsed> DBTablesUsed = db.tblDBTablesUseds
             .Where(x => x.fldReportID == Report.fldReportID).ToList(); //execute DB query using ToList()
         List<tblReport> reports = db.tblReports
             .Where(rep => DBTablesUsed.Select(x => x.fldReportID).Contains(rep.fldReportID)
             .ToList();
         List<tblDBTable> tables= db.tblDBTables
             .Where(rep => DBTablesUsed.Select(x => x.fldTableName).Contains(rep.fldTableName)
             .ToList(); 
         rvm.report = reports;
         rvm.dbtables = tables;
    
         return View(rvm);
    }
