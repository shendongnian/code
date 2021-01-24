            public ActionResult ExportData()
        {
            GridView gv = new GridView();
            var data = db.web_weeklyreports.Include(w => w.web_kategori).Include(w => w.web_kategori1).Include(w => w.web_kategori2).Include(w => w.web_kategori3).Include(w => w.web_kategori4).ToList();
            gv.AutoGenerateColumns = false;
            gv.Columns.Add(new ImageField { HeaderText="IMG",  DataImageUrlField = "Imagepath", DataImageUrlFormatString = "https://localhost:44353/img/{0}.jpeg",  });
            gv.Columns.Add(new BoundField { HeaderText="ID", DataField = "ID" });
            gv.Columns.Add(new BoundField { HeaderText="Email", DataField = "emailid" });
            gv.Columns.Add(new BoundField { HeaderText="Date", DataField = "date" });
            gv.Columns.Add(new BoundField { HeaderText="Task 1", DataField = "task1" });
            gv.Columns.Add(new BoundField { HeaderText="", DataField = "t1kategoriid" });
            gv.Columns.Add(new BoundField { HeaderText="", DataField = "task2" });
            gv.Columns.Add(new BoundField { HeaderText="", DataField = "t2kategoriid" });
            gv.Columns.Add(new BoundField { HeaderText="", DataField = "task3" });
            gv.Columns.Add(new BoundField { HeaderText="", DataField = "t3kategoriid" });
            gv.Columns.Add(new BoundField { HeaderText="", DataField = "task4" });
            gv.Columns.Add(new BoundField { HeaderText="", DataField = "t4kategoriid" });
            gv.Columns.Add(new BoundField { HeaderText="", DataField = "task5" });
            gv.Columns.Add(new BoundField { HeaderText="", DataField = "t5kategoriid" });
            DataTable dt = new DataTable();
            dt.Columns.Add("Imagepath");
            dt.Columns.Add("ID");
            dt.Columns.Add("emailid");
            dt.Columns.Add("date");
            dt.Columns.Add("task1");
            dt.Columns.Add("t1kategoriid");
            dt.Columns.Add("task2");
            dt.Columns.Add("t2kategoriid");
            dt.Columns.Add("task3");
            dt.Columns.Add("t3kategoriid");
            dt.Columns.Add("task4");
            dt.Columns.Add("t4kategoriid");
            dt.Columns.Add("task5");
            dt.Columns.Add("t5kategoriid");
            foreach (var item in data)
            {                 
                dt.Rows.Add(item.emailid, item.ID, item.emailid, item.date, item.task1, item.t1kategoriid, item.task2, item.t2kategoriid, item.task3, item.t3kategoriid, item.task4, item.t4kategoriid, item.task5, item.t5kategoriid);                
            }
            gv.DataSource = dt;
            gv.DataBind();
            for (int i = 0; i < data.Count; i++)
            {
                gv.Rows[i].Height = 40;
            }
            
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=WeeklyReports.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("adminreports");
        }
