      public ActionResult PrintReprtForSpecicDates(DateTime startdate, DateTime enddate)
        {
            using (ProDbDataContext _Context = new ProDbDataContext())
            {
                List<Sp_GetSpecificRecordResult> RecordList = _Context.Sp_GetSpecificRecord(startdate,enddate).ToList();
                var dt = Helper.Helper.ToDataTable(RecordList);
                RptGetSpecificRecords reportobj = new RptGetSpecificRecords();
                reportobj.DataSource = dt;
                reportobj.Parameters["Startdate"].Value = Convert.ToDateTime(startdate).ToShortDateString();
                reportobj.Parameters["Enddate"].Value = Convert.ToDateTime(enddate).ToShortDateString();
                var stream = new MemoryStream();
                reportobj.ExportToPdf(stream);
                return File(stream.GetBuffer(), "application/pdf");
            }
        }
