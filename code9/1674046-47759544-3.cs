    using System;
    using System.IO;
    using System.Collections.Generic;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace TestAnything
    {
        class Program
        {
          
            static void Main(string[] args)
            {
                List<string> filesToMerge = new List<string> { @"c:\temp\1.pdf", @"c:\temp\2.pdf" };
                FileInfo destinationFile = new FileInfo(@"c:\temp\merge.pdf");
                if (File.Exists(destinationFile.FullName))
                    File.Delete(destinationFile.FullName);
                MergeFiles(filesToMerge, destinationFile);
            }
    
    
            public static void MergeFiles(List<string> sourceFiles, FileInfo destinationFile)
            {
                if (sourceFiles == null || sourceFiles.Count == 0)
                    throw new ArgumentNullException("blahhh.");
    
                PdfReader reader = new PdfReader(sourceFiles[0]);
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                PdfCopy writer = new PdfCopy(document, new FileStream(destinationFile.FullName, FileMode.Create));
                document.Open();
                try
                {
                    foreach (string sourceFile in sourceFiles)
                    {
                        reader = new PdfReader(sourceFile);
                        reader.ConsolidateNamedDestinations();
    
                        for (int x = 1; x <= reader.NumberOfPages; x++)
                            writer.AddPage(writer.GetImportedPage(reader, x));
    
                        PRAcroForm form = reader.AcroForm;
                        if (form != null)
                            writer.CopyAcroForm(reader);
                    }
                }
                finally
                {
                    if (document.IsOpen())
                        document.Close();
                }
            }
        }
    }
