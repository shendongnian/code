    string fileName = "~/AuthDoc/" + Convert.ToString(consentMain.AppointmentId) +".pdf";                              
    string newFile = System.Web.Hosting.HostingEnvironment.MapPath(fileName);
    PdfReader reader = new PdfReader(consentDoc); // get pdf byte from datbase
    FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
    var stamper = new PdfStamper(reader, fs);
    var pdfContentByte = stamper.GetOverContent(1);
    iTextSharp.text.Image PatientSign = iTextSharp.text.Image.GetInstance(consentMain.PatientSign); // image from database
    PatientSign.SetAbsolutePosition(100, 100);
    pdfContentByte.AddImage(PatientSign);
    stamper.Close();
    reader.Close();
    byte[] bytes = System.IO.File.ReadAllBytes(newFile);
    return bytes;
