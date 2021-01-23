    private static bool? saveExcelPackageDialog(string fileName, string workingDirectory, byte[] rawBinaryObject)
    {
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = EXCEL_FILTER_FILE_DIALOG;
        sfd.InitialDirectory = workingDirectory;
        sfd.FileName = fileName;
        bool? result = sfd.ShowDialog();
        if (result == true)
        {
            File.WriteAllBytes(sfd.FileName, rawBinaryObject);
            System.Diagnostics.Process.Start(sfd.FileName);
        }
        return result;
    }
