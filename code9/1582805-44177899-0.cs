    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using DevExpress.XtraReports.UI;
    // ... 
    
    private void Form1_Load(object sender, EventArgs e) {
        XtraReport1 report = new XtraReport1();
        report.DataSource = CreateData();
    
        ReportPrintTool tool = new ReportPrintTool(report);
        tool.ShowPreview();
    }
    
    private  List<Data> CreateData() {
        List<Data> data = new List<Data>();
    
        Data item1 = new Data();
        item1.Date = DateTime.Now;
        item1.Id = 0;
        item1.Name = "First";
        data.Add(item1);
    
        Data item2 = new Data();
        item2.Date = DateTime.Now;
        item2.Id = 1;
        item2.Name = "Second";
        data.Add(item2);
    
        Data item3 = new Data();
        item3.Date = DateTime.Now;
        item3.Id = 2;
        item3.Name = "Third";
        data.Add(item3);
    
        return data;
    }
