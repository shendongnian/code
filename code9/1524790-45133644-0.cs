        var _sourceFile = " PATH TO YOUR TEMPLATE FILE ";
        using (var templateFile = File.Open(_sourceFile, FileMode.Open, FileAccess.Read))
            {
                using (var stream = new MemoryStream())
                {
                    templateFile.CopyTo(stream);
                    using (var spreadsheetDocument = SpreadsheetDocument.Open(stream, true))
                    {                
                        spreadsheetDocument.ChangeDocumentType(SpreadsheetDocumentType.MacroEnabledWorkbook);
                    }
                    byte[] buffer = stream.ToArray();
                    MemoryStream ms = new MemoryStream(buffer);
                    FileStream file = new FileStream(System.IO.Path.GetDirectoryName(_sourceFile) + "/SaveMEW.xlsm",
                        FileMode.Create, FileAccess.Write);
                    ms.WriteTo(file);
                    file.Close();
                }
            }
