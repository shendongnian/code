    using System.IO;
    Report report = PXReportTools.LoadReport("AP642010", null);
    if (report == null) return;
    parameters["StartCheckNbr"] = payment.ExtRefNbr;
    PXReportTools.InitReportParameters(report, parameters, PXSettingProvider.Instance.Default);
     ReportNode repNode = ReportProcessor.ProcessReport(report);
     var streamMgr = new StreamManager();
     string format = ReportProcessor.FilterPdf;
     var renderFilter = ReportProcessor.GetRenderer(format);
     renderFilter.Render(repNode, null, streamMgr);
     streamMgr.MainStream.Flush();
     streamMgr.MainStream.Seek(0, System.IO.SeekOrigin.Begin);
    string file = @"C:\Temp\AP642010.pdf";
    string tempPath = Path.GetTempPath();
    string path = Path.Combine(tempPath, Path.GetFileName(file));
    var mystream = new MemoryStream(System.IO.File.ReadAllBytes(path));
    sender.AddAttachment(path, mystream.ToArray());`
