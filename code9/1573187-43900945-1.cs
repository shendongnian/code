    public static void SendEmailWithExcelAttachment(DataTable dt)
        {
            try
            {
                string smptHost = smptTuple.Item1;
                MailMessage mailMsg = new MailMessage();
                string temp = Path.GetTempPath(); // Get %TEMP% path
                string file = "fileNameHere.xlsx";
                string path = Path.Combine(temp, file); // Get the whole path to the file
                FileInfo fi = new FileInfo(path);
                using (ExcelPackage pck = new ExcelPackage(fi))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Table");
                    ws.Cells["A1"].LoadFromDataTable(dt, true);
                    pck.Save();
                }
                mailMsg.Attachments.Add(new System.Net.Mail.Attachment(path, "application/vnd.ms-excel"));
                try
                {
                    //send email
                    smtp.Send(mailMsg);
                }
                catch (Exception)
                {
                    //do smth..
                }
                finally
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
