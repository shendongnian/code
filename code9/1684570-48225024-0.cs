    public void saveDoc(string doc)
        {
            string path = @"\\servername\folder\sub-folder\";
            string filename = path + doc + ".pdf";
            try
            {
                this.Application.ActiveDocument.ExportAsFixedFormat(filename, WdExportFormat.wdExportFormatPDF);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
