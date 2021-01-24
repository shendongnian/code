    CloudBlockBlob zipblob = new CloudBlockBlob(new Uri("https://brucechen.blob.core.windows.net/brucechen/LogTable.zip"));
    using (var msZippedBlob = new MemoryStream())
    {
        zipblob.DownloadToStream(msZippedBlob);
        using (ZipArchive zip = new ZipArchive(msZippedBlob))
        {
            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                if (entry.FullName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using (var stream = entry.Open())
                    {
                        var wk = new XSSFWorkbook(stream); //HSSFWorkbook for xls
                        var sheet = wk.GetSheetAt(0);
                        IRow row = sheet.GetRow(0);
                        for (int i = 0; i <= sheet.LastRowNum; i++)
                        {
                            row = sheet.GetRow(i);
                            if (row != null)
                            {
                                for (int j = 0; j < row.LastCellNum; j++)
                                {
                                    string value = row.GetCell(j).ToString();
                                    Console.Write(value.ToString() + " ");
                                }
                                Console.WriteLine("\n");
                            }
                        }
                    }
                }
            }
        }
    }
