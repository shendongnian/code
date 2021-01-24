         static void Main(string[] args)
            {
                ValidateLicense();
    
                var sourcePdfPath = Path.Combine(
                                        Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), 
                                        "<your_xfa_pdf_file>");
                var destinationPdfPath = Path.Combine(
                                            Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), 
                                            "output.pdf");
                FlattenPDF(sourcePdfPath, destinationPdfPath);
            }
            private static void ValidateLicense()
            {
                var licenseFileLocation = Path.Combine(
                                            Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                                            "itextkey.xml");
    
                iTextSharp.license.LicenseKey.LoadLicenseFile(licenseFileLocation);
            }
    
            private static void FlattenPDF(string sourcePdfPath, string destinationPdfPath)
            {
                using (var sourcePdfStream = File.OpenRead(sourcePdfPath))
                {
                    var document = new iTextSharp.text.Document();
                    var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(
                                    document, 
                                    new FileStream(destinationPdfPath, FileMode.Create));
                    var xfaf = new iTextSharp.tool.xml.xtra.xfa.XFAFlattener(document, writer);
                    sourcePdfStream.Position = 0;
                    xfaf.Flatten(new iTextSharp.text.pdf.PdfReader(sourcePdfStream));
                    document.Close();
                }
            }
