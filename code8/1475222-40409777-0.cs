    private void reportViewer1_ReportExport(object sender, 
        Microsoft.Reporting.WinForms.ReportExportEventArgs e)
    {
        e.Cancel = true;
        string mimeType;
        string encoding;
        string fileNameExtension;
        string[] streams;
        Microsoft.Reporting.WinForms.Warning[] warnings;
        var bytes = reportViewer1.LocalReport.Render(e.Extension.Name, e.DeviceInfo,
                        Microsoft.Reporting.WinForms.PageCountMode.Actual, out mimeType,
                        out encoding, out fileNameExtension, out streams, out warnings);
        var path = string.Format(@"d:\file.{0}", fileNameExtension);
        System.IO.File.WriteAllBytes(path, bytes);
        MessageBox.Show(string.Format("Exported to {0}", path));
    }
