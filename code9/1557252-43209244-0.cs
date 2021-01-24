    foreach (DataRow r in dt.Rows)
    {
      foreach(DataColumn column in dt.Columns)
      {
        if (r[column] != null)
        {
         var res = (from d in dc.Doctors
         join ct in dc.CTUsers on d.id equals ct.DoctorId
         where ct.CTid == ctid && ct.SiteId == Int32.Parse(r[column].ToString())
         select d).FirstOrDefault();
         r["Assessment"] = res.Assessment;
        }                     
      }
      data.Add(r);
    }
